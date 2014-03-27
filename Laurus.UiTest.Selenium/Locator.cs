using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	// TODO: this still seems pretty shabby
    // i'd really like to figure out how to send a key-value pair to the code that actually looks for items
	public class SeleniumLocator : By, ILocator
	{
		public SeleniumLocator(Locator locator)
		{
			if (locator.Key.Equals(LocatorKey.Id.ToString()))
			{
				this.By = By.Id(locator.Value);
			}
			if (locator.Key.Equals(LocatorKey.Class.ToString()))
			{
				this.By = By.ClassName(locator.Value);
			}
			if (locator.Key.Equals(LocatorKey.Css.ToString()))
			{
				this.By = By.CssSelector(locator.Value);
			}
			if (locator.Key.Equals(LocatorKey.Name.ToString()))
			{
				this.By = By.Name(locator.Value);
			}
            if(locator.Key.Equals(LocatorKey.TagName.ToString()))
			{
				this.By = By.TagName(locator.Value);
			}
            if(locator.Key.Equals(LocatorKey.Xpath.ToString()))
			{
				this.By = By.XPath(locator.Value);
			}
		}

		//public SeleniumLocator(Locator locator) : base(Find, InternalFindElements)
		//{
		//	this.By = By.Name(locator.Value);
		//}

		//private static IWebElement Find(ISearchContext context)
		//{
		//	throw new NotImplementedException();
		//}

		//private static ReadOnlyCollection<IWebElement> InternalFindElements(ISearchContext context)
		//{
		//	throw new NotImplementedException();
		//}

		public By By { get; set; }
	}
}
