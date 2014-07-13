using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class NavigationTests : IUseFixture<WebFixture>
	{
        [Fact]
        public void AbsoluteNavigation()
		{
			_web.Test.Navigate("http://www.google.com");
		}

        [Fact]
        public void RelativeNavigation()
		{
			_web.Test.Navigate("http://www.google.com");
			_web.Test.Navigate("/maps");
		}

		public void SetFixture(WebFixture data)
		{
			_web = data;
		}

		private WebFixture _web;
	}
}
