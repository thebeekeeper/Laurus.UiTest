using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.WebDriver.Util
{
    public class SessionStartup
	{
		public DesiredCapabilities desiredCapabilities { get; set; }
	}

    public class SessionStartupResponse
	{
		public int status { get; set; }
		public string sessionId { get; set; }
		public string state { get; set; }
	}

	public class DesiredCapabilities
	{
		public string browserName { get; set; }
	}
}
