using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	public class LocatorFactory : INativeLocatorFactory
	{
		ILocator INativeLocatorFactory.Build(Locator locator)
		{
            return new SeleniumLocator(locator);
		}
	}
}
