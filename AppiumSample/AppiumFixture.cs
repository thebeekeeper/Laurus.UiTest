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
		public IWebDriver GetDriver()
		{
			var desiredCaps = new DesiredCapabilities();
			desiredCaps.SetCapability("device", "Android");
			desiredCaps.SetCapability("browserName", "");
			desiredCaps.SetCapability("version", "4.2");
			desiredCaps.SetCapability("app", "sauce-storage:fd.zip");
			desiredCaps.SetCapability("app-package", "com.example.FdMobile");
			desiredCaps.SetCapability("app-activity", ".SplashActivity");
			desiredCaps.SetCapability("username", "thebeekeeper");
			// the key is case sensitive!
			desiredCaps.SetCapability("accessKey", "54087e46-dd23-453c-80e9-f6db35a4eeae");
			desiredCaps.SetCapability("deviceType", "phone");
			var uri = "http://ondemand.saucelabs.com:80/wd/hub";
			_driver = new RemoteWebDriver(new Uri(uri), desiredCaps, TimeSpan.FromMinutes(5));
			return _driver;
		}

		public void Dispose()
		{
			_driver.Close();
			_driver.Dispose();
		}

		private IWebDriver _driver;
	}
}
