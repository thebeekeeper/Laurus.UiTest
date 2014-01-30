using Laurus.UiTest;
using Laurus.UiTest.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class ScreenshotAspect : IPageAspect
	{
		public ScreenshotAspect(ITest test)
		{
			_test = test;
		}

		public void BeforeControl(Type t)
		{
			_test.TakeScreenshot(Guid.NewGuid().ToString() + ".png");
		}

		public void AfterControl(Type pageType)
		{
		}

		private readonly ITest _test;
	}
}
