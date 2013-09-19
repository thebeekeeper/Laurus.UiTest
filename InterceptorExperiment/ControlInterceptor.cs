using Castle.DynamicProxy;
using Laurus.UiTest.Locators;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorExperiment
{
	[Serializable]
    public class ControlInterceptor : IInterceptor
    {
		public ControlInterceptor(IWebDriver driver)
		{
			_driver = driver;
		}

		public void Intercept(IInvocation invocation)
		{
			MethodInfo methodInfo = invocation.MethodInvocationTarget;
			if (methodInfo == null)
			{
				methodInfo = invocation.Method;
			}
			var nameAttr = (NameAttribute)invocation.TargetType.GetCustomAttributes(typeof(NameAttribute), false).First();
			_by = By.Name(nameAttr.Value);
			//if (invocation.Method.Name.Equals("Find"))
			//{
			//	var finder = (NameSelector)invocation.Arguments.First();
			//	var name = finder.Name;
			//	_by = By.Name(name);
			//}
			if (invocation.Method.Name.Equals("Click"))
			{
				var element = _driver.FindElement(_by);
				element.Click();
			}
			if (invocation.Method.Name.Equals("set_Text"))
			{
				var text = (string)invocation.Arguments.First();
				var element = _driver.FindElement(_by);
				element.SendKeys(text);
			}
		}

		private readonly IWebDriver _driver;
		private By _by;
	}
}
