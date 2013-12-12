using Laurus.UiTest.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	public class BaseControl : IBaseControl
	{
		public BaseControl(IWebDriver driver)
		{
			_driver = driver;
		}

		void IBaseControl.Find(ILocator locator)
		{
			this._by = ((SeleniumLocator)locator).By;
		}

		bool IBaseControl.IsVisible()
		{
			try
			{
				return this.GetNative().Displayed;
			}
			catch (NoSuchElementException)
			{
				return false;
			}
		}

		protected IWebElement GetNative()
		{
			return _driver.FindElement(_by);
		}

		private readonly IWebDriver _driver;
		private By _by;
	}
}
