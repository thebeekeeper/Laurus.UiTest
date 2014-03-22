using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Laurus.UiTest
{
	public class PageMap<T>
	{
        public PageMap()
		{
			_locators = new Dictionary<string, string>();
		}

		public void AddToMap(Expression<Func<T, IBaseControl>> control, string name, string value)
		{
			var propertyExpression = (MemberExpression)control.Body;
			var key = propertyExpression.Member.Name;
			_locators.Add(key, name);
		}

		public String GetLocator(string property)
		{
			return _locators[property];
		}

		private Dictionary<string, string> _locators;
	}
}
