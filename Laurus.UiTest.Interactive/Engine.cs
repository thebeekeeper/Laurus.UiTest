using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Interactive
{
	public class Engine
	{
		public Engine()
		{
			_scriptEngine = new ScriptEngine();
			_scriptEngine.AddReference("System");
			_scriptEngine.AddReference(this.GetType().Assembly.Location);
			_scriptEngine.AddReference("Laurus.UiTest.dll");
			_scriptEngine.AddReference("Laurus.UiTest.Selenium.dll");

			_scriptEngine.ImportNamespace("System");
			_scriptEngine.ImportNamespace("Laurus.UiTest");
			_scriptEngine.ImportNamespace("Laurus.UiTest.Controls");
			_scriptEngine.ImportNamespace("Laurus.UiTest.Selenium");
			_scriptEngine.ImportNamespace("System.Collections.Generic");

			// TODO: temp
			_scriptEngine.AddReference("Laurus.UiTest.Interactive.Pages.dll");
			_scriptEngine.ImportNamespace("Laurus.UiTest.Interactive.Pages");
			_scriptEngine.AddReference("Savo.Mobile.UiTest.Ios.dll");
			_scriptEngine.ImportNamespace("Savo.Mobile.UiTest.Ios.Pages");
		}

		public void Begin()
		{
			_session = _scriptEngine.CreateSession();
		}

		public void Execute(string code)
		{
			var sub = _session.CompileSubmission<object>(code);
			var exe = sub.Execute();
		}

		private readonly ScriptEngine _scriptEngine;
		private Session _session;
	}
}
