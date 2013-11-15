using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class ScreenshotTests : IUseFixture<WebFixture>
	{
		[Fact]
		public void Can_Save_Screenshot()
		{
			var path = @"c:\temp\ss.png";
			_fixture.Test.TakeScreenshot(path);
			Assert.True(System.IO.File.Exists(path));
		}

		public void SetFixture(WebFixture data)
		{
			_fixture = data;
			_fixture.StartBrowser();
		}

		private WebFixture _fixture;
	}
}
