using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Laurus.UiTest.WebDriver
{
	public class LocatorParser
	{
        public LocatorCriteria Parse(Expression<Func<UiElement, bool>> locator)
		{
			var body = locator.Body;
            switch(body.NodeType)
			{
				case ExpressionType.Equal:
				case ExpressionType.NotEqual:
					return VisitBinary((BinaryExpression)body);
                case ExpressionType.Call:
                    // TODO: make method calls usable in expressions (if possible)
					throw new Exception("Method calls are not allowed in locator expressions yet");
					//return VisitCall((MethodCallExpression)body);
				default:
                    // TODO: custom exception type
					throw new Exception("No parser for this type of expression");
			}
		}

        private LocatorCriteria VisitBinary(BinaryExpression e)
		{
			var left = (MemberExpression)e.Left;
			var right = (ConstantExpression)e.Right;
			return new LocatorCriteria(left.Member.Name.Replace("_", " ").ToLower(), right.Value.ToString());
		}

        private LocatorCriteria VisitCall(MethodCallExpression exp)
		{
			return null;
		}
	}

    public class UiElement
	{
		public string Class_Name { get; set; }
		public string Css_Selector { get; set; }
		public string Id { get; set; }
		public string Name { get; set; }
		public string Link_Text { get; set; }
		public string Tag_Name { get; set; }
		public string Xpath { get; set; }
    }
}
