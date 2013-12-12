using Laurus.UiTest;
using Laurus.UiTest.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSample
{
	public class AppiumFixture : IDisposable
	{
		public ITest Test { get; set; }

		public AppiumFixture()
		{
			var desiredCaps = new Dictionary<string, object>()
			{
				{ "device", "Android" },
				{ "browserName", "" },
				{ "version", "4.2" },
				{ "app", "http://appium.s3.amazonaws.com/NotesList.apk" },
				{ "app-package", "com.example.android.notepad" },
				{ "app-activity", ".NotesList" },
				{ "deviceType", "phone" },
			};
			var p = new StartupParameters()
			{
				RemoteHost = "http://localhost:4723/wd/hub",
				BrowserType = BrowserType.Remote,
			};
			Test = new SeleniumTest(desiredCaps, p);
		}

		public void Dispose()
		{
			Test.Quit();
		}
	}
}
