using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Laurus.UiTest.WebDriver.UnitTest
{
    public class ExpressionParserTests
    {
		[Fact]
		public void EqualsExpression_Returns_CriteriaAndValue()
		{
			var p = new LocatorParser();
			var c = p.Parse(f => f.Id == "hello");
			Assert.Equal("id", c.Criteria);
			Assert.Equal("hello", c.Value);
		}

    }
}
