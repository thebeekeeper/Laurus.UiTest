using Castle.DynamicProxy;
using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorExperiment
{
	[Serializable]
	public class PageInterceptor : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			if (invocation.Method.IsGetter() || invocation.Method.IsSetter())
			{
				// remove get/set prefix
				var propertyName = invocation.Method.Name.Substring(4);
				var pageType = invocation.Method.DeclaringType;
				var control = pageType.GetProperties().Where(p => p.Name.Equals(propertyName)).FirstOrDefault();
				if (control == default(PropertyInfo))
				{
					throw new Exception("Invalid control");
				}
				var locatorAttr = control.GetCustomAttribute<LocatorAttribute>();
			}
		}
	}

	// thinking about dynamically creating control implementations.  maybe later
	//public class ControlBuilder
	//{
	//	public T BuildControl<T>(string locator) where T : IBaseControl
	//	{
	//		return default(T);
	//	}
	//}

	public static class MethodInfoExtensions
	{
		public static bool IsGetter(this MethodInfo methodInfo)
		{
			return methodInfo.Name.StartsWith("get_");
		}

		public static bool IsSetter(this MethodInfo methodInfo)
		{
			return methodInfo.Name.StartsWith("set_");
		}
	}
}
