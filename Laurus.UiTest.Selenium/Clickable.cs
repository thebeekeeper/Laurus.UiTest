using Laurus.UiTest.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	public class Clickable : BaseControl, IClickable
	{
		public Clickable(IWebDriver driver)
			: base(driver)
		{
			_driver = driver;
		}

		public void Click()
		{
			this.GetNative().Click();
		}

		public string Text { get { return this.GetNative().Text; } }

		public void Tap()
		{
            //((RemoteWebDriver)_driver).
		}

		private IWebDriver _driver;
	}
}
