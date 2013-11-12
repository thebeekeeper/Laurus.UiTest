using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	public class LocatorFactory : ILocatorFactory
	{
		ILocator ILocatorFactory.BuildLocator(LocatorAttribute selector)
		{
			if (String.IsNullOrEmpty(selector.Name) == false)
			{
				return new Locator()
				{
					Name = "name",
					Value = selector.Name,
				};
			}
			else if (string.IsNullOrEmpty(selector.Id) == false)
			{
				return new Locator()
				{
					Name = "id",
					Value = selector.Id
				};
			}
			else if (String.IsNullOrEmpty(selector.TagName) == false)
			{
				return new Locator()
				{
					Name = "tagName",
					Value = selector.TagName
				};
			}
			return null;
		}
	}
}
