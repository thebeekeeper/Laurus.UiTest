using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Laurus.UiTest.WebDriver
{
	public class ExpressionLocator
	{
		//public void Add<T>(Expression<Func<UiElement, T>> locator)
        public void Add(Expression<Func<UiElement, bool>> locator)
            //public void AddToMap(Expression<Func<T, IBaseControl>> control, string name, string value)
		{
			//var x = (MemberExpression)locator;
			//x.Member.Name;
			var e = (BinaryExpression)locator.Body;
			var left = (MemberExpression)e.Left;
			var right = (ConstantExpression)e.Right;
			var x = left.Member.Name + " = " + right.Value;
			Console.Write(x);
		}

        public void Add2(Func<UiElement, bool> locator)
		{
            locator.ToString();
		}

        public void test()
		{
			Add2(f => f.Id == "Test");
			this.Add(f => f.Id.Equals("test"));
		}
	}

    public class UiElement
	{
        public string Class {get;set;}
        public string Id {get;set;}
    }

    public class Locator
	{

	}
}
