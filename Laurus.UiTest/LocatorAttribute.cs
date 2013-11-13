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
		public string Expression { get; protected set; }

		public LocatorAttribute(string expression)
		{
			Expression = expression;
		}
	}
}
