using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Laurus.UiTest.Selenium.UnitTest
{
    [Trait("Kind", "Unit")]
	public class LocatorTests
	{
        [Fact]
        public void Name_Locator_Populates_By()
		{
            var value = Guid.NewGuid().ToString();
			var l = new Locator() { Key = LocatorKey.Name.ToString(), Value = value };
			var s = new SeleniumLocator(l);
			var stringVal = s.By.ToString();
			Assert.True(stringVal.Contains("By.Name"));
			Assert.True(stringVal.Contains(value));
		}

        [Fact]
        public void Id_Locator_Populates_By()
		{
            var value = Guid.NewGuid().ToString();
			var l = new Locator() { Key = LocatorKey.Id.ToString(), Value = value };
			var s = new SeleniumLocator(l);
			var stringVal = s.By.ToString();
			Assert.True(stringVal.Contains("By.Id"));
			Assert.True(stringVal.Contains(value));
		}

        [Fact]
        public void Css_Locator_Populates_By()
		{
            var value = Guid.NewGuid().ToString();
			var l = new Locator() { Key = LocatorKey.Css.ToString(), Value = value };
			var s = new SeleniumLocator(l);
			var stringVal = s.By.ToString();
			Assert.True(stringVal.Contains("By.Css"));
			Assert.True(stringVal.Contains(value));
		}

        [Fact]
        public void Xpath_Locator_Populates_By()
		{
            var value = Guid.NewGuid().ToString();
			var l = new Locator() { Key = LocatorKey.Xpath.ToString(), Value = value };
			var s = new SeleniumLocator(l);
			var stringVal = s.By.ToString();
			Assert.True(stringVal.Contains("By.XPath"));
			Assert.True(stringVal.Contains(value));
		}
        
        [Fact]
        public void Class_Locator_Populates_By()
		{
            var value = Guid.NewGuid().ToString();
			var l = new Locator() { Key = LocatorKey.Class.ToString(), Value = value };
			var s = new SeleniumLocator(l);
			var stringVal = s.By.ToString();
			Assert.True(stringVal.Contains("By.Class"));
			Assert.True(stringVal.Contains(value));
		}

        [Fact]
        public void TagName_Locator_Populates_By()
		{
            var value = Guid.NewGuid().ToString();
			var l = new Locator() { Key = LocatorKey.TagName.ToString(), Value = value };
			var s = new SeleniumLocator(l);
			var stringVal = s.By.ToString();
			Assert.True(stringVal.Contains("By.TagName"));
			Assert.True(stringVal.Contains(value));
		}
	}
}
