using Laurus.UiTest;
using Laurus.UiTest.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSample
{
	public class ScreenshotAspect : IPageAspect
	{
		public ScreenshotAspect(ITest test)
		{
			_test = test;
		}

		public void BeforeControl(Type t)
		{
			_test.TakeScreenshot(Guid.NewGuid().ToString());
		}

		public void AfterControl(Type pageType)
		{
			throw new NotImplementedException();
		}

		private readonly ITest _test;
	}
}
