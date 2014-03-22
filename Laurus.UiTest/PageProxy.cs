using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Security.Permissions;
using System.Text;

namespace Laurus.UiTest
{
	public class PageProxy<T> : RealProxy where T : IPage
	{
        [PermissionSet(SecurityAction.LinkDemand)]
        public PageProxy(PageMap<T> map) : base(typeof(T))
		{ 
		
		}

		public override System.Runtime.Remoting.Messaging.IMessage Invoke(System.Runtime.Remoting.Messaging.IMessage msg)
		{
			throw new NotImplementedException();
		}
	}
}
