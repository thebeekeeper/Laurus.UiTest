using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest
{
	public class TestBuilder
	{
		public BrowserType Browser { get; set; }
		public TimeSpan ImplicitWait { get; set; }
		public Dictionary<string, object> Capabilities { get; set; }
		public Func<Type, bool> PageMapSelector { get; set; }

        public TestBuilder()
		{
			Capabilities = new Dictionary<string, object>();
            // by default use whatever page map is available
            PageMapSelector = (x) => true;
		}
	}

    public static class TestBuilderExtensions
	{
        public static TestBuilder WithFirefox(this TestBuilder test)
		{
			test.Browser = BrowserType.Firefox;
			return test;
		}

        public static TestBuilder WithHeadless(this TestBuilder test)
		{
			//test.Browser = BrowserType.Remote;
			test.Browser = BrowserType.PhantomJs;
			return test;
		}

        public static TestBuilder ImplicitWait(this TestBuilder test, TimeSpan implicitWait)
		{
			test.ImplicitWait = implicitWait;
			return test;
		}

        public static TestBuilder WithCapability(this TestBuilder test, string name, string value)
		{
			test.Capabilities.Add(name, value);
			return test;
		}

        public static TestBuilder SelectMapsBy(this TestBuilder test, Func<Type, bool> selector)
		{
			test.PageMapSelector = selector;
			return test;
		}

        /// <summary>
        /// Selects maps to use by matching the given value to maps with Platform("platformName")
        /// </summary>
        /// <param name="test"></param>
        /// <param name="platformName">Platform name to use when selecting maps</param>
        /// <returns></returns>
        public static TestBuilder SelectMapsWithPlatform(this TestBuilder test, string platformName)
		{
			test.SelectMapsBy(mapType =>
			{
                // NOTE: we _should_ be looking for base class attributes in case a user wants 
				// to create a base page map class which is useful for adding helper mapping methods
				var attr = mapType.GetCustomAttributes(typeof(PlatformAttribute), true);
				if (attr.Any())
				{
					return ((PlatformAttribute)attr.First()).Platfom.Equals(platformName);
				}
				return false;
			});
			return test;
		}
	}
}
