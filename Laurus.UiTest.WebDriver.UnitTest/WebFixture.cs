using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.WebDriver.UnitTest
{
	public class WebFixture : IDisposable
	{
		public Session Session { get; set; }

		public WebFixture()
		{
			var file = @"..\..\..\SampleWebApp\biography.html";
			var targetPath = Path.GetTempFileName() + ".html";
			File.Copy(file, targetPath);
			var startUrl = "file://" + targetPath;
            Session = Server.StartSession("http://apollo:4444");
			Session.Browser.Uri = new Uri(startUrl);
		}

		void IDisposable.Dispose()
		{
			Session.Delete();
		}
	}
}
