using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest
{
	// this should be implemented in driver specific assemblies
	public abstract class SelectorBase
	{
		public abstract ILocator ToLocator();
	}
}
