using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Laurus.UiTest.WebDriver.UnitTest
{
	public class SessionTests
	{
		[Fact]
		public void Can_Start_Remote_Session()
		{
			var s = Server.StartSession("http://apollo:4444");
			s.Browser.Uri = new Uri("http://thebeekeeper.net");
			var hello = s.Locate(new LocatorCriteria("id", "footer"));
			hello.Click();
			var txt = hello.Text;
			Console.Write(txt);
			var enabled = hello.Enabled;
			Console.Write(enabled);
			//var l = hello.Location;
			s.Delete();
		}
	}
}
