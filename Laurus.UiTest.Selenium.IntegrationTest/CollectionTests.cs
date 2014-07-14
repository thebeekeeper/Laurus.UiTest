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
			var items = page.ListItems;
            // maybe need a custom ICollection implementation to get accurate counts?
			//Assert.Equal(3, items.Count());
			Assert.Equal("three", items.ElementAt(2).Text);
		}

		[Fact]
		public void Can_Find_List_Items_By_Id_Mutation()
		{
			var page = _fixture.Test.GetPage<IBiographyPage>();
			var items = page.ListItems;
			Assert.NotEqual(2, items.Count());
		}

		public void SetFixture(WebFixture data)
		{
			_fixture = data;
		}

		private WebFixture _fixture;
	}
}
