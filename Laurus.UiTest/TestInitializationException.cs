using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest
{
	public class TestInitializationException : Exception
	{
		public TestInitializationException(string message, Exception inner)
			: base(message, inner)
		{ }
	}
}
