using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest
{
	public class StartupParameters
	{
		public BrowserType BrowserType { get; set; }
		public string RemoteHost { get; set; }
		public TimeSpan ImplicitWait { get; set; }

        public StartupParameters()
		{
			ImplicitWait = TimeSpan.FromSeconds(0);
		}
	}

	public enum BrowserType
	{
		Firefox,
		Chrome,
		InternetExplorer,
		Remote,
        PhantomJs,
	}
}
