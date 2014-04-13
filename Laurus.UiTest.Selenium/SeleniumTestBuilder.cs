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
            try
			{
				return new SeleniumTest(builder.Capabilities, startupParams, builder.PageMapSelector);
			}
            catch(Exception e)
			{
                throw new TestInitializationException("Failed to initialize test driver", e);
			}
		}

        public static ITest UsingSeleniumRemote(this TestBuilder builder, string remoteHost)
		{
			var startupParams = new StartupParameters()
			{
				BrowserType = BrowserType.Remote,
				ImplicitWait = builder.ImplicitWait,
				RemoteHost = remoteHost,
			};
            try
			{
				return new SeleniumTest(builder.Capabilities, startupParams, builder.PageMapSelector);
			}
            catch(Exception e)
			{
                throw new TestInitializationException("Failed to initialize test driver", e);
			}
		}

        public static ITest StartAt(this ITest test, string url)
		{
			test.Navigate(url);
			return test;
		}
	}
}
