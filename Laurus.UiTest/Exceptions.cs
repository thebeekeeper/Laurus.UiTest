using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest
{
    public class ControlNotMappedException : Exception
	{
		public ControlNotMappedException(string controlName)
			: base(String.Format("No mapping for {0} found", controlName))
		{ }
	}

    public class MapNotFoundException : Exception
	{
		public MapNotFoundException(Type mapType)
			: base(String.Format("Map not found for page {0}", mapType.Name))
		{ }
	}
}
