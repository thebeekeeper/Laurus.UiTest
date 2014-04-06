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
			_locators = new Dictionary<string, Locator>();
		}

        public PageMap(string defaultLocatorKey) : this()
		{
			_defaultLocator = defaultLocatorKey;
		}

		public void AddToMap(Expression<Func<T, IBaseControl>> control, string name, string value)
		{
			var propertyExpression = (MemberExpression)control.Body;
			var key = propertyExpression.Member.Name;
			_locators.Add(key, new Locator() { Key = name, Value = value });
		}

		public void AddToMap(Expression<Func<T, IBaseControl>> control, LocatorKey name, string value)
		{
            AddToMap(control, name.ToString(), value);
		}

        /// <summary>
        /// Adds a control to the page map using the default locator key
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
		public void AddToMap(Expression<Func<T, IBaseControl>> control, string value)
		{
            if(string.IsNullOrEmpty(_defaultLocator))
			{
				throw new ControlNotMappedException("Default locator key is not set");
			}
			AddToMap(control, _defaultLocator, value);
		}

		public void AddToMap<TControl>(Expression<Func<T, ICollection<TControl>>> control, string name, IEnumerable<string> values)
		{
            // TODO: add collection of locators - maybe replace Locator in the dictionary?
		}

		public Locator GetLocator(string property)
		{
            if(!_locators.ContainsKey(property))
			{
				throw new ControlNotMappedException(property);
			}
			return _locators[property];
		}

		private Dictionary<string, Locator> _locators;
		private string _defaultLocator;
	}

}
