using Castle.DynamicProxy;
using Castle.Windsor;
using Laurus.UiTest.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest
{
	[Serializable]
	public class PageInterceptor : IInterceptor
	{
		public PageInterceptor(IControlRegistry controls)
		{
			_controls = controls;
		}

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
				var controlType = control.PropertyType;
				var selector = new NameSelector(locatorAttr.Name);
				var controlImpl = _controls.GetControl(controlType, selector);

				invocation.ReturnValue = controlImpl;
			}
			else
			{
				throw new InvalidOperationException("Proxy called on non property");
			}
		}

		// TODO: this is essentially a service locator - not sure how to get rid of it
		private readonly IControlRegistry _controls;
	}

	// thinking about dynamically creating control implementations.  maybe later
	// - would probably have to be driver implementation specific
	//public class ControlBuilder
	//{
	//	public T BuildControl<T>(string locator) where T : IBaseControl
	//	{
	//		return default(T);
	//	}
	//}
}
