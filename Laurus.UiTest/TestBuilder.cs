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

        public TestBuilder()
		{
			Capabilities = new Dictionary<string, object>();
		}
	}

    public static class TestBuilderExtensions
	{
        public static TestBuilder WithFirefox(this TestBuilder test)
		{
			test.Browser = BrowserType.Firefox;
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
	}
}
