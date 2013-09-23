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
		public override IWebElement FindElement(ISearchContext context)
		{
			return base.FindElement(context);
		}

		public override System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
		{
			return base.FindElements(context);
		}
	}
}
