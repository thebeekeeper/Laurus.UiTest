using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.WebDriver
{
	public class LocatorCriteria
	{
        public LocatorCriteria(string criteria, string value)
		{
			Criteria = criteria;
			Value = value;
		}

		public string Criteria { get; set; }
		public string Value { get; set; }
	}
}
