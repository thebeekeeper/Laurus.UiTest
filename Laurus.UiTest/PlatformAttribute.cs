using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest
{
	public class PlatformAttribute : Attribute
	{
		public string Platfom { get; set; }

        public PlatformAttribute(string name)
		{
			Platfom = name;
		}
	}
}
