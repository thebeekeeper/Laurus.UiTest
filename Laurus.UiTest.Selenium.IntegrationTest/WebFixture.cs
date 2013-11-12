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
			Test = new SeleniumTest();
		}

		public void StartBrowser()
		{
			var file = @"..\..\..\SampleWebApp\biography.html";
			var targetPath = Path.GetTempFileName() + ".html";
			File.Copy(file, targetPath);
			Test.Navigate("file://" + targetPath);
		}

		void IDisposable.Dispose()
		{
			Test.Quit();
		}
	}
}
