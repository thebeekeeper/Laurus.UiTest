using AppiumSample.Pages;
using Laurus.UiTest;
using Laurus.UiTest.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace AppiumSample
{
	public class TestClass1 : IUseFixture<AppiumFixture>
	{
		[Fact]
		public void MyTest()
		{
			var bioPage = _fixture.Test.GetPage<BioPage>();
			bioPage.Name.Text = "bob loblaw";
		}

		public void SetFixture(AppiumFixture data)
		{
			_fixture = data;
		}

		private AppiumFixture _fixture;
	}
}
