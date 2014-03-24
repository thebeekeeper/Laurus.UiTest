using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.Selenium
{
	public static class SeleniumTestBuilder
	{
        public static ITest UsingSeleniumDriver(this TestBuilder builder)
		{
			var startupParams = new StartupParameters()
			{
				BrowserType = builder.Browser,
				ImplicitWait = builder.ImplicitWait,
				RemoteHost = "",
			};
			return new SeleniumTest(builder.Capabilities, startupParams);
		}

        public static ITest UsingSeleniumRemote(this TestBuilder builder, string remoteHost)
		{
			var startupParams = new StartupParameters()
			{
				BrowserType = BrowserType.Remote,
				ImplicitWait = builder.ImplicitWait,
				RemoteHost = remoteHost,
			};
			return new SeleniumTest(builder.Capabilities, startupParams);
		}

        public static ITest StartAt(this ITest test, string url)
		{
			test.Navigate(url);
			return test;
		}
	}
}
