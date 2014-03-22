using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

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
