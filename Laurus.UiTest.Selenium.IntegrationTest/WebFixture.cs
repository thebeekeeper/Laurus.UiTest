using System;
using System.IO;
using Laurus.UiTest;
using Laurus.UiTest.Selenium;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class WebFixture : IDisposable
	{
		public ITest Test { get; set; }

		public WebFixture()
		{
			var file = @"..\..\..\SampleWebApp\biography.html";
			var targetPath = Path.GetTempFileName() + ".html";
			File.Copy(file, targetPath);
			var startUrl = "file://" + targetPath;
			Test = new TestBuilder()
				.WithFirefox()
                .UsingSeleniumDriver()
                .StartAt(startUrl);
		}

		void IDisposable.Dispose()
		{
			Test.Quit();
		}
	}
}
