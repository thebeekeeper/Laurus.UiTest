using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Locators
{
	public abstract class TagNameSelector : SelectorBase
	{
		public string TagName { get; protected set; }

		public TagNameSelector(string tagName)
		{
			TagName = tagName;
		}
	}
}
