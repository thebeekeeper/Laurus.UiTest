using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	public class ScreenshotRemoteWebDriver : RemoteWebDriver, ITakesScreenshot, IRotatable
	{
		public ScreenshotRemoteWebDriver(Uri address, ICapabilities caps, TimeSpan timeout)
			: base(address, caps, timeout)
		{ }

		public Screenshot GetScreenshot()
		{
			var response = this.Execute(DriverCommand.Screenshot, null);
			return new Screenshot(response.Value.ToString());
		}

		public ScreenOrientation Orientation
		{
			get
			{
				var response = this.Execute("/session/{0}/orientation", new Dictionary<string, object>());
				if (response.Value.Equals("LANDSCAPE"))
					return ScreenOrientation.Landscape;
				return ScreenOrientation.Portrait;
			}
			set
			{
				var response = this.Execute("/session{0}/orientation", new Dictionary<string,object>() { { "orientation", "LANDSCAPE" } });
			}
		}
	}
}
