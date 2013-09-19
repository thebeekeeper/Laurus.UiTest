using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Locators
{
	[AttributeUsage(AttributeTargets.Property, Inherited = false)]
	public class NameAttribute : Attribute
	{
		public NameAttribute(string value)
		{
			Value = value;
		}

		public string Value { get; set; }
	}
}
