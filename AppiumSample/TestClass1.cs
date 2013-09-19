using AppiumSample.Pages;
using Laurus.UiTest;
using Laurus.UiTest.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace AppiumSample
{
	public class TestClass1 : IUseFixture<AppiumFixture>
	{
//		[Fact]
		public void MyTest()
		{
			//ITest test = new SeleniumTest(_driver);
			//var bioPage = test.GetPage<BioPage>();
			//bioPage.Name.Text = "bob loblaw";
		}

		public void SetFixture(AppiumFixture data)
		{
			_driver = data.GetDriver();
		}

		private IWebDriver _driver;
	}
}
