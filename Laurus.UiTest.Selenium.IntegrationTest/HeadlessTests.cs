using Laurus.UiTest.Selenium.IntegrationTest.Pages;
using Laurus.UiTest.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class HeadlessTests
	{
        [Fact]
        public void Headless_Google_Search()
		{
			var test = new TestBuilder().WithHeadless().UsingSeleniumDriver();
			test.Navigate("http://www.google.com");
			//test.TakeScreenshot(@"e:\temp\sshot1.png");
			var home = test.GetPage<IGoogleHomePage>();
			home.SearchBox.Text = "barf";
			home.SearchButton.Click();
			//test.TakeScreenshot(@"e:\temp\sshot2.png");
			test.Quit();
		}

		[Fact]
		public void Firefox_Google_Search()
		{
			var test = new TestBuilder().WithFirefox().UsingSeleniumDriver();
			test.Navigate("http://www.google.com");
			var home = test.GetPage<IGoogleHomePage>();
			home.SearchBox.Text = "barf";
			home.SearchButton.Click();
			test.Quit();
		}

	
	}
}
