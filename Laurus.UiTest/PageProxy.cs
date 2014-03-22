﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Security.Permissions;
using System.Text;

namespace Laurus.UiTest
{
	public class PageProxy<T> : RealProxy where T : IPage
	{
        [PermissionSet(SecurityAction.LinkDemand)]
        public PageProxy(PageMap<T> map, INativeLocatorFactory locatorConverter, IControlRegistry controlRegistry) : base(typeof(T))
		{
			_pageMap = map;
			_converter = locatorConverter;
			_controlRegistry = controlRegistry;
		}

		public override IMessage Invoke(IMessage msg)
		{
            var methodCall = msg as IMethodCallMessage;
            
            object nativeControl = null;
            if(msg.IsGetter())
			{
				var locator = _pageMap.GetLocator(msg.PropertyName());
				var nativeLocator = _converter.Build(locator);
				nativeControl = _controlRegistry.GetControl(msg.PropertyType(), nativeLocator);
			}
			else
			{
				// should only ever be getter - it doesn't make sense to set a page element
				throw new InvalidOperationException("Can't set page elements");
			}

            var returnMessage = new ReturnMessage(nativeControl, null, 0, methodCall.LogicalCallContext, methodCall);
			return returnMessage;
		}

		private readonly PageMap<T> _pageMap;
		private readonly INativeLocatorFactory _converter;
		private readonly IControlRegistry _controlRegistry;
	}

	public static class IMessageExtensions
	{
        public static bool IsGetter(this IMessage msg)
		{
			return ((string)msg.Properties[MethodName]).StartsWith("get_");
		}

        public static string PropertyName(this IMessage msg)
		{
			var s = ((string)msg.Properties[MethodName]);
			return s.Substring(4);
		}

        public static Type PropertyType(this IMessage msg)
		{
			var m = (IMethodCallMessage)msg;
			var methodInfo = m.MethodBase as MethodInfo;
			return methodInfo.ReturnType;
		}

		private static readonly string MethodName = "__MethodName";
	}
}