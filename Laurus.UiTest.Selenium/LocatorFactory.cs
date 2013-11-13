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
			return ExpressionLocator.Expression(selector.Expression);
		}
	}
}
