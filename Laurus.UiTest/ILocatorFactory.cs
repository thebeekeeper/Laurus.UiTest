using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest
{
	public interface ILocatorFactory
	{
		ILocator BuildLocator(LocatorAttribute selector);
	}
}
