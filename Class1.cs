using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExampleForNick
{
	public class ActionDetails
	{
		public string Controller { get; set; }
		public string Action { get; set; }
		public Dictionary<string, object> Values { get; set; }
	}

	public static class UrlRequestor
	{
		public static TModel Request<TController, TModel>(Expression<Func<TController, ActionResult>> selector) where TController : Controller
		{
			var details = selector.GetDetails();
			
			//TODO: find out the specific assembly attribute added to web application to identify the VDir for the application
			//typeof(TController).Assembly.GetCustomAttributes("ApplicationAttribute").First().ApplicationName;
			var appliction = "Teams"; 
			

			//TODO: Build the url from the details above and make the http request
			// i.e. something that looks like the following or using another "builder"
			
			var url = "http://localhost:5050/" + appliction + "/" + details.Controller + "/" + details.Action + "?" + "[query string built from details.Values"; 

			return default(TModel); //make your http request here using the URL from above and parse the result
		}

		internal static ActionDetails GetDetails<T>(this Expression<Func<T, ActionResult>> selector) where T : Controller
		{
			var methodCallExpression = (MethodCallExpression)selector.Body;
			var method = methodCallExpression.Method;
			var parameters = method.GetParameters();
			var values = GetParameterValues(selector);
			var dictionary = parameters
				.Zip(values, (p, v) => new { p.Name, v })
				.ToDictionary(item => item.Name, item => item.v);
			var controller = typeof(T).Name.Replace("Controller", string.Empty);

			return new ActionDetails() { Controller = controller, Action = method.Name, Values = dictionary };
		}

		private static object[] GetParameterValues(LambdaExpression expression)
		{
			var methodCallExpression = expression.Body as MethodCallExpression;
			if (methodCallExpression != null)
			{
				return methodCallExpression.Arguments.Select(GetValue).ToArray();
			}

			//TODO: this should throw an exception
			return null;
		}

		private static object GetValue(Expression expression)
		{
			var constantExpression = expression as ConstantExpression;
			if (constantExpression != null)
			{
				return constantExpression.Value;
			}

			var objectMember = Expression.Convert(expression, typeof(object));
			var getterLambda = Expression.Lambda<Func<object>>(objectMember);
			var getter = getterLambda.Compile();
			return getter();
		}
	}
}
