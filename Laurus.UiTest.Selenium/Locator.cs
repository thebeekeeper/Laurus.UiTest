using Laurus.UiTest.Locators;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	public class Locator : By, ILocator
	{
		public new string Name { get; set; }
		public string Value { get; set; }

		public override IWebElement FindElement(ISearchContext context)
		{
			if (Name.Equals("name"))
			{
				return By.Name(Value).FindElement(context);
			}
			else if (Name.Equals("id"))
			{
				return By.Id(Value).FindElement(context);
			}
			else if (Name.Equals("tagName"))
			{
				return By.TagName(Value).FindElement(context);
			}
			throw new Exception("Locator not found");
		}

		public override System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
		{
			return base.FindElements(context);
		}
	}
}
