using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class TestBuilderTests
	{
        [Fact]
        public void CanCreateSeleniumTest()
		{
			var test = new TestBuilder()
				.WithFirefox()
				.UsingSeleniumDriver();
			Assert.NotNull(test);

			test.Quit();
		}
	}
}
