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
			_fixture.Test.TakeScreenshot(@"e:\temp\sshot.png");
			page.Name.Text = "asdf";
			page.Age.Text = "12";
			page.Relationship.Text = "something";
			page.NextButton.Click();
			var result = page.Result.Text;
			Assert.Equal("asdf", result);
		}

        [Fact]
        public void CanFindSelect()
		{
			var page = _fixture.Test.GetPage<IBiographyPage>();
			page.PetPreference.SelectedText = "rats";
		}

        [Fact]
        public void CanGetLinkText()
		{
			var page = _fixture.Test.GetPage<IBiographyPage>();
			var t = page.LinkWithText.Text;
			Assert.Equal("link text", t);
		}

		public void SetFixture(WebFixture data)
		{
			_fixture = data;
		}

		private WebFixture _fixture;
	}
}
