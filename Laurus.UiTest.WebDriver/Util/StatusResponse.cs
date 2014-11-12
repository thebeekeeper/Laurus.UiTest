using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.WebDriver.Util
{
	public class StatusResponse
	{
		public string sessionId { get; set; }
		public int status { get; set; }
		public string state { get; set; }
		public string value { get; set; }
		//public string @class { get; set; }
		//public long hCode { get; set; }
	}

    public class LocatorResponse
	{
		public string sessionId { get; set; }
		public int status { get; set; }
		public string state { get; set; }
		public LocatorValue value { get; set; }
	}

    public class LocatorValue
	{
		public int ELEMENT { get; set; }
	}
}
