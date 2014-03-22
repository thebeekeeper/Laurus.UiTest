using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest
{
	public interface INativeLocatorFactory
	{
		ILocator Build(Locator locator);
	}
}
