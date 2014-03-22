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
			Test = new TestBuilder()
				.WithCapability("device", "Android")
				.WithCapability("browserName", "")
				.WithCapability("version", "4.2")
				.WithCapability("app", "http://appium.s3.amazonaws.com/NotesList.apk")
				.WithCapability("app-package", "com.example.android.notepad")
				.WithCapability("app-activity", ".NotesList")
				.WithCapability("deviceType", "phone")
				.ImplicitWait(TimeSpan.FromSeconds(30))
				.UsingSeleniumRemote("http://localhost:4723/wd/hub");
		}

		public void Dispose()
		{
			Test.Quit();
		}
	}
}
