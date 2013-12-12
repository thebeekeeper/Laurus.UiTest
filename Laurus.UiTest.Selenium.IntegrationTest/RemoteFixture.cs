using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class RemoteFixture : IDisposable
	{
		public ITest Test { get; set; }

		public RemoteFixture()
		{
			var desiredCaps = new Dictionary<string, object>()
			{
				{"device", ""},
				{"browserName", ""},
				{"version", "6.0"},
				{"app", "/Users/administrator/savo.zip"},
				{"deviceType", "phone"},
				{"platform", "Mac"},
			};
			var startup = new StartupParameters()
			{
				RemoteHost = "http://10.1.7.97:4723/wd/hub",
				BrowserType = Laurus.UiTest.BrowserType.Remote,
				ImplicitWait = TimeSpan.FromSeconds(10),
			};

			Test = new SeleniumTest(desiredCaps, startup);
		}

		void IDisposable.Dispose()
		{
			Test.Quit();
		}
	}
}
