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
	public class Editable : IEditable, IBaseControl
	{
		public string Text 
		{
			get 
			{
				_element = GetNative();
				return _element.Text; 
			}
			set 
			{
				_element = GetNative();
				_element.SendKeys(value);
			} 
		}

		public Editable(IWebDriver driver)
		{
			_driver = driver;
		}

		void IBaseControl.Find(SelectorBase selector)
		{
			var isName = (selector as NameSelector) != null;
			var isTagName = (selector as TagNameSelector) != null;

			if (isName)
			{
				_finder = By.Name(((NameSelector)selector).Name);
			}
			else if(isTagName)
			{
				_finder = By.TagName(((TagNameSelector)selector).TagName);
			}
		}

		void IBaseControl.Find(ILocator locator)
		{
			this._finder = (By)locator;
		}

		IWebElement GetNative()
		{
			return _driver.FindElement(_finder);
		}

		bool IBaseControl.IsVisible()
		{
			return GetNative().Displayed;
		}

		private IWebDriver _driver;
		private IWebElement _element;
		private By _finder;
	}
}
