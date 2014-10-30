using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class TestTests : IUseFixture<WebFixture>
	{
        [Fact]
        public void CanGetPageSource()
		{
			var source = _fixture.Test.Source();
			var expected = "relationEdit";
			Assert.True(source.Contains(expected));	
		}

		public void SetFixture(WebFixture data)
		{
			_fixture = data;
		}

		private WebFixture _fixture;
	}
}
