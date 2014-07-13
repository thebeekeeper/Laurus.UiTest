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
			test.Quit();
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
			test.Quit();
		}

		//[Fact]
        // i don't remember what this test is supposed to do
		public void Page_With_SubPage()
		{
			var test = new TestBuilder()
				.WithHeadless()
				.UsingSeleniumDriver();
			var page = test.GetPage<ILoginPage>();
			page.Login.Username.Text = "asdf";
			page.Login.Password.Text = "password";
			page.Login.Submit.Click();

            Assert.Equal("asdf|password", page.Header.Text);
			test.Quit();
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
