using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Locators
{
	public class NameSelector : SelectorBase
	{
		public string Name { get; protected set; }

		public NameSelector(string name)
		{
			Name = name;
		}
	}
}
