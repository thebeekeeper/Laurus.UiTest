using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class DummyAspect : IPageAspect
	{
		public void BeforeControl(Type pageType)
		{
			System.Diagnostics.Debug.WriteLine("BeforeControl");
		}

		public void AfterControl(Type pageType)
		{
			System.Diagnostics.Debug.WriteLine("AfterControl");
		}
	}
}
