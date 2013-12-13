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
			//var desiredCaps = new Dictionary<string, object>()
			//{
			//	{"device", ""},
			//	{"browserName", ""},
			//	{"version", "6.0"},
			//	{"app", "/Users/administrator/savo.zip"},
			//	{"deviceType", "phone"},
			//	{"platform", "Mac"},
			//};
			//var startup = new StartupParameters()
			//{
			//	RemoteHost = "http://10.1.7.97:4723/wd/hub",
			//	BrowserType = Laurus.UiTest.BrowserType.Remote,
			//	ImplicitWait = TimeSpan.FromSeconds(10),
			//};

			var desiredCaps = new Dictionary<string, object>()
			{
				{ "device" , "Android" },
				{ "browserName" , "" },
				{ "version" , "4.2" },
				{ "app" , "/Users/administrator/android.zip" },
				//{ "app" , Settings.AppUrl },
				{ "app-package" , "com.savo.android.apps.mobile" },
				{ "app-activity" , ".ui.SplashPageActivity" }
			};
			var startup = new StartupParameters()
			{
				BrowserType = Laurus.UiTest.BrowserType.Remote,
				RemoteHost = "http://10.1.7.97:4723/wd/hub",
				ImplicitWait = TimeSpan.FromSeconds(30),
			};


			Test = new SeleniumTest(desiredCaps, startup);
			Test.SetOrientation(Orientation.Landscape);
		}

		void IDisposable.Dispose()
		{
			Test.Quit();
		}
	}
}
