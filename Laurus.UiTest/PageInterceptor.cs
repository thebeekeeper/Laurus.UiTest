﻿//using Castle.DynamicProxy;
//using Castle.Windsor;
//using Laurus.UiTest.Controls;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace Laurus.UiTest
//{
//	[Serializable]
//	public class PageInterceptor : IInterceptor
//	{
//		public PageInterceptor(IControlRegistry controls, ILocatorFactory locatorFactory, IEnumerable<IPageAspect> pageAspects)
//		{
//			_controls = controls;
//			_locatorFactory = locatorFactory;
//			_pageAspects = pageAspects.ToList();
//		}

//		public PageInterceptor(IControlRegistry controls, ILocatorFactory locatorFactory)
//		{
//			_controls = controls;
//			_locatorFactory = locatorFactory;
//			_pageAspects = Enumerable.Empty<IPageAspect>().ToList();
//		}

//		public void Intercept(IInvocation invocation)
//		{
//			if (invocation.Method.IsGetter() || invocation.Method.IsSetter())
//			{
//				// remove get/set prefix
//				var propertyName = invocation.Method.Name.Substring(4);
//				var pageType = invocation.Method.DeclaringType;

//				_pageAspects.ForEach(a => a.BeforeControl(pageType));

//				var control = pageType.GetProperties().Where(p => p.Name.Equals(propertyName)).FirstOrDefault();
//				if (control == default(PropertyInfo))
//				{
//					throw new Exception("Invalid control");
//				}
//				var locatorAttr = control.GetCustomAttribute<LocatorAttribute>();
//				var locator = _locatorFactory.BuildLocator(locatorAttr);
//				var controlType = control.PropertyType;

//				object controlImpl = null;
//				if (controlType.IsCollection())
//				{
//					var controls = new List<IBaseControl>();
//					var innerType = controlType.GetGenericArguments();
//					for(int i = 1 ; i < innerType.Length + 1 ; i++)
//					{
//						// TODO: this is fairly dumb
//						var locatorStr = String.Format(locatorAttr.Expression, i);
//						locatorAttr = new LocatorAttribute(locatorStr);
//						locator = _locatorFactory.BuildLocator(locatorAttr);
//						var c = _controls.GetControl(innerType[i - 1], locator) as IBaseControl;
//						controls.Add(c);
//					}
//					controlImpl = controls;
//				}
//				else
//				{
//					controlImpl = _controls.GetControl(controlType, locator);
//				}

//				invocation.ReturnValue = controlImpl;

//				_pageAspects.ForEach(a => a.AfterControl(pageType));
//			}
//			else
//			{
//				throw new InvalidOperationException("Proxy called on non property");
//			}
//		}

//		// TODO: this is essentially a service locator - not sure how to get rid of it
//		private readonly IControlRegistry _controls;
//		private readonly ILocatorFactory _locatorFactory;
//		private readonly List<IPageAspect> _pageAspects;
//	}

//	public static class PropertyInfoExtensions
//	{
//		public static T GetCustomAttribute<T>(this PropertyInfo propertyInfo)
//		{
//			var attr = propertyInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
//			return (T)attr;
//		}
//	}

//	// thinking about dynamically creating control implementations.  maybe later
//	// - would probably have to be driver implementation specific
//	//public class ControlBuilder
//	//{
//	//	public T BuildControl<T>(string locator) where T : IBaseControl
//	//	{
//	//		return default(T);
//	//	}
//	//}
//}
