using Laurus.UiTest.Selenium.IntegrationTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class DefaultLocatorTests : IUseFixture<WebFixture>
	{
        [Fact]
        public void Can_Locate_With_Defaults()
		{
			var page = _fixture.Test.GetPage<IBiographyPage2>();
			page.Name.Text = "asdf";
			page.Age.Text = "12";
			page.Relationship.Text = "something";
			page.NextButton.Click();
			var result = page.Result.Text;
			Assert.Equal("asdf", result);
		}

		public void SetFixture(WebFixture data)
		{
			_fixture = data;
		}

		private WebFixture _fixture;
	}
}
