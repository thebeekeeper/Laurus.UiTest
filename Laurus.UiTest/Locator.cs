using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest
{
	public class Locator 
	{
		public string Key { get; set; }
		public string Value { get; set; }
	}

    public class CollectionLocator : Locator
	{
        public CollectionLocator(string name, IEnumerable<string> values)
		{
			this.Key = name;
			this.Values = values;
		}

		public IEnumerable<string> Values { get; set; }
	}
}
