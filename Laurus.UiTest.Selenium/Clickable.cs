using Laurus.UiTest.Controls;
using Laurus.UiTest.Locators;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	public class Clickable : IBaseControl, IClickable
	{
		public Clickable(IWebDriver driver)
		{
			_driver = driver;
		}

		public void Click()
		{
			_element = _driver.FindElement(_by);
			_element.Click();
		}

		void IBaseControl.Find(SelectorBase selector)
		{
			var name = ((NameSelector)selector).Name;
			_by = By.Name(name);
		}

		bool IBaseControl.IsVisible()
		{
			_element = _driver.FindElement(_by);
			return _element.Displayed;
		}

		IWebElement _element;
		By _by;
		IWebDriver _driver;
	}
}
