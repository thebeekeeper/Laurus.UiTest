using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest
{
	[AttributeUsage(AttributeTargets.Property)]
	public class LocatorAttribute : Attribute
	{
		public string Name { get; protected set; }

		// TODO: needs to take named parameters
		public LocatorAttribute(string name)
		{
			Name = name;
		}
	}
}
