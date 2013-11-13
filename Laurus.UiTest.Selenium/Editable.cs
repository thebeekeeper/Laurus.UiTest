using Laurus.UiTest.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	public class Editable : BaseControl, IEditable
	{
		public Editable(IWebDriver driver)
			: base(driver)
		{ }

		public string Text
		{
			get { return this.GetNative().Text; }
			set { this.GetNative().SendKeys(value); }
		}
	}
}
