using Laurus.UiTest.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.Selenium
{
	public class Select : BaseControl, ISelect
	{
		public Select(IWebDriver driver)
			: base(driver)
		{ }

		public string SelectedText
		{
			get
			{
				return new SelectElement(this.GetNative()).SelectedOption.Text;
			}
			set
			{
				new SelectElement(this.GetNative()).SelectByText(value);
			}
		}
	}
}
