using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	public class ScreenshotRemoteWebDriver : RemoteWebDriver, ITakesScreenshot
	{
		public ScreenshotRemoteWebDriver(Uri address, ICapabilities caps, TimeSpan timeout)
			: base(address, caps, timeout)
		{ }

		public Screenshot GetScreenshot()
		{
			var response = this.Execute(DriverCommand.Screenshot, null);
			return new Screenshot(response.Value.ToString());
		}
	}
}
