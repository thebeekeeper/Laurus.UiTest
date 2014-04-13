using Laurus.UiTest.Selenium.IntegrationTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class MultiPlatformTests
	{
        [Fact]
        public void Can_Create_Test_For_OtherPlatform()
		{
			var test = new TestBuilder()
                .WithHeadless()
			    .SelectMapsBy(x => SelectMap(x))
			    .UsingSeleniumDriver();
			var page = test.GetPage<IBiographyPage2>();
			Assert.Equal("By.Id: biographyNext", page.NextButton.ToString());
		}

		[Fact]
		public void Can_Create_Test_For_OtherPlatform_WithBuilder()
		{
			var test = new TestBuilder()
				.WithHeadless()
                .SelectMapsWithPlatform("OtherPlatform")
				.UsingSeleniumDriver();
			var page = test.GetPage<IBiographyPage2>();
			Assert.Equal("By.Id: biographyNext", page.NextButton.ToString());
		}

        public bool SelectMap(Type mapType)
		{
			var mapAttrValue = "OtherPlatform";
            var attr = mapType.GetCustomAttributes(typeof(PlatformAttribute), false);
            if(attr.Any())
			{
				return ((PlatformAttribute)attr.First()).Platfom.Equals(mapAttrValue);
			}
			return false;
		}
	}
}
