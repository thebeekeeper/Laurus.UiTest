using Laurus.UiTest.Selenium.IntegrationTest.Pages;
using SampleWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class ClickableDiscoveryTests : IUseFixture<WebFixture>
	{
		[Fact]
		public void CanFindClickable()
		{
			var page = _fixture.Test.GetPage<IBiographyPage>();
			page.Name.Text = "asdf";
			page.Age.Text = "12";
			page.Relationship.Text = "something";
			page.NextButton.Click();
			var result = page.Result.Text;
			Assert.Equal("asdf", result);
		}

        [Fact]
        public void CanSearchGoogle()
		{
			var page = _fixture.Test.GetPage<IGoogleHomePage>();
			page.SearchBox.Text = "robot";
			page.SearchButton.Click();
		}


		public void SetFixture(WebFixture data)
		{
			_fixture = data;
			_fixture.StartBrowser();
		}

		private WebFixture _fixture;
	}
}
