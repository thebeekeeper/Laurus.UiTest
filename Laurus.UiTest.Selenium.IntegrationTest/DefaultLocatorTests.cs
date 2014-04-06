using Laurus.UiTest.Selenium.IntegrationTest.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class DefaultLocatorTests : IUseFixture<InstrumentedPageFixture>
	{
        [Fact]
        public void Can_Locate_With_Defaults()
		{
			var page = _fixture.Test.GetPage<IInstrumentedPage>();
			page.Name.Text = "asdf";
			page.Age.Text = "12";
			page.Submit.Click();
			var result = page.Result.Text;
			Assert.Equal("asdf", result);
		}

		public void SetFixture(InstrumentedPageFixture data)
		{
			_fixture = data;
		}

		private InstrumentedPageFixture _fixture;
	}

    public class InstrumentedPageFixture : IDisposable
	{
		public InstrumentedPageFixture()
		{
			var file = @"..\..\..\SampleWebApp\instrumentedpage.html";
			var targetPath = Path.GetTempFileName() + ".html";
			File.Copy(file, targetPath);
			var startUrl = "file://" + targetPath;
			Test = new TestBuilder()
				.WithFirefox()
				.UsingSeleniumDriver()
				.StartAt(startUrl);
		}

		public void Dispose()
		{
			Test.Quit();
		}

		public ITest Test { get; set; }

	}
}
