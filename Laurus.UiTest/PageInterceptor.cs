﻿using Castle.DynamicProxy;
using Castle.Windsor;
using Laurus.UiTest.Controls;
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
		public PageInterceptor(IControlRegistry controls, ILocatorFactory locatorFactory, IPageAspect pageAspect)
		{
			_controls = controls;
			_locatorFactory = locatorFactory;
			_pageAspect = pageAspect;
		}

		public void Intercept(IInvocation invocation)
		{
			if (invocation.Method.IsGetter() || invocation.Method.IsSetter())
			{
				// remove get/set prefix
				var propertyName = invocation.Method.Name.Substring(4);
				var pageType = invocation.Method.DeclaringType;

				_pageAspect.BeforeControl(pageType);

				var control = pageType.GetProperties().Where(p => p.Name.Equals(propertyName)).FirstOrDefault();
				if (control == default(PropertyInfo))
				{
					throw new Exception("Invalid control");
				}
				var locatorAttr = control.GetCustomAttribute<LocatorAttribute>();
				var locator = _locatorFactory.BuildLocator(locatorAttr);
				var controlType = control.PropertyType;

				object controlImpl = null;
				if (controlType.IsCollection())
				{
					var controls = new List<IBaseControl>();
					var innerType = controlType.GetGenericArguments();
					for(int i = 1 ; i < innerType.Length + 1 ; i++)
					{
						// TODO: this is fairly dumb
						var locatorStr = String.Format(locatorAttr.Expression, i);
						locatorAttr = new LocatorAttribute(locatorStr);
						locator = _locatorFactory.BuildLocator(locatorAttr);
						var c = _controls.GetControl(innerType[i - 1], locator) as IBaseControl;
						controls.Add(c);
					}
					controlImpl = controls;
				}
				else
				{
					controlImpl = _controls.GetControl(controlType, locator);
				}

				invocation.ReturnValue = controlImpl;
			}
			else
			{
				throw new InvalidOperationException("Proxy called on non property");
			}
		}

		// TODO: this is essentially a service locator - not sure how to get rid of it
		private readonly IControlRegistry _controls;
		private readonly ILocatorFactory _locatorFactory;
		private readonly IPageAspect _pageAspect;
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
