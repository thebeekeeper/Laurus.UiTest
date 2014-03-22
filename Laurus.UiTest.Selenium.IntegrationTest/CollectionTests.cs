using SampleWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class CollectionTests : IUseFixture<WebFixture>
	{
		[Fact]
		public void Can_Find_List_Items_By_Id()
		{
			var page = _fixture.Test.GetPage<IBiographyPage>();
			var itemCount = page.ListItems.Count();
			Assert.Equal(3, itemCount);
		}

		public void SetFixture(WebFixture data)
		{
			_fixture = data;
		}

		private WebFixture _fixture;
	}
}
