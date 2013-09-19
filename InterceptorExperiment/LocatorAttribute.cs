using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorExperiment
{
	public class LocatorAttribute : Attribute
	{
		public string Name { get; protected set; }

		public LocatorAttribute(string name)
		{
			Name = name;
		}
	}
}
