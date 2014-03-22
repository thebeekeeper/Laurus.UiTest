using Laurus.UiTest.Selenium.IntegrationTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class MapGenTests
	{
        [Fact]
        public void GetMaps()
		{
			var f = new PageFactory(new LocatorFactory(), new ControlRegistry(null));
			var map = f.GetPage<IGoogleHomePage>();
			Assert.NotNull(map);
		}
	}
}
