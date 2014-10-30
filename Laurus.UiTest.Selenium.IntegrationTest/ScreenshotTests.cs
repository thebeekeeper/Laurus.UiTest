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

        [Fact]
        public void Can_Get_Automatic_Screenshot()
		{
			var file = _fixture.Test.TakeScreenshot();
			Assert.True(System.IO.File.Exists(file));
		}

		public void SetFixture(WebFixture data)
		{
			_fixture = data;
		}

		private WebFixture _fixture;
	}
}
