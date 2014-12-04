using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Laurus.UiTest.WebDriver.UnitTest
{
	public class ElementLocationTests : IUseFixture<WebFixture>
	{
        [Fact]
        public void CanLocateElementById()
		{
			var link = _web.Session.Find(f => f.Id == "linkWithText");
			Assert.Equal("link text", link.Text);
		}

        [Fact]
        public void CanLocateElementByClass()
		{
			var l = _web.Session.Find(f => f.Class_Name == "testSpan");
			Assert.Equal("test span", l.Text);
		}

        [Fact]
        public void CanLocateElementByCss()
		{

		}

        [Fact]
        public void CanLocateElementByName()
		{
			var link = _web.Session.Find(f => f.Name == "namedElement");
			Assert.Equal("i have a name", link.Text);
		}

        [Fact]
        public void CanLocateElementByLinkText()
		{
			var link = _web.Session.Find(f => f.Link_Text == "complete text");
			Assert.True(link.Enabled);
		}

        [Fact]
        public void CanLocateElementByTagName()
		{
			var a = _web.Session.Find(f => f.Tag_Name == "article");
			Assert.Equal("here's an article", a.Text);
		}

        [Fact]
        public void CanLocateElementByXpath()
		{

		}

		public void SetFixture(WebFixture data)
		{
			_web = data;
		}

		private WebFixture _web;
	}
}
