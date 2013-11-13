using Laurus.UiTest.Selenium;
using Mono.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Interactive
{
	class Program
	{
		static void Main(string[] args)
		{
			var e = new Engine();
			e.Begin();

			LineEditor le = new LineEditor(null);
			string s;

			e.Execute("ITest test = new SeleniumTest(new Dictionary<string, object>(), new StartupParameters() { BrowserType = BrowserType.Firefox });");
			while ((s = le.Edit("shell> ", "")) != null)
			{
				Console.WriteLine("----> [{0}]", s);
				e.Execute(s);
			}
			e.Execute("test.Quit();");
		}

		void init()
		{
			var test = new SeleniumTest(new Dictionary<string, object>(), new StartupParameters() { BrowserType = BrowserType.Firefox });
		}
	}
}
