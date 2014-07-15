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
            foreach(var x in typeof(T).GetProperties())
			{
				_locators.Add(x.Name, new Locator() { Key = _defaultLocator, Value = x.Name });
			}
		}

		public void AddToMap(Expression<Func<T, IBaseControl>> control, string name, string value)
		{
			var propertyExpression = (MemberExpression)control.Body;
			var key = propertyExpression.Member.Name;
			//_locators.Add(key, new Locator() { Key = name, Value = value });
			_locators[key] = new Locator() { Key = name, Value = value };
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

        // TODO: this should take IReadOnlyCollection because it doesn't make sense to add to the collection later on
        // need to update to .NET 4.5+ for IReadOnlyCollection
		public void AddToMap<TControl>(Expression<Func<T, ICollection<TControl>>> control, string name, IEnumerable<string> values)
		{
			var propertyExpression = (MemberExpression)control.Body;
			var key = propertyExpression.Member.Name;
			_locators[key] = new CollectionLocator(name, values);
		}

        public void AddToMap<TControl>(Expression<Func<T, IEnumerable<TControl>>> control, string name, Func<int, string> locator)
		{
			var propertyExpression = (MemberExpression)control.Body;
			var key = propertyExpression.Member.Name;
            // TODO: don't do this
            // should this just be a ControlEnumeration?
			var s = new string[100];
			for (int i = 0; i < s.Length; i++)
			{
				s[i] = locator.Invoke(i);
			}
			_locators[key] = new CollectionLocator(name, s);
		}

		//public void AddToMap(Expression<Func<T, IPage>> subPage, string name, string value)
		//{
		// adds a sub-page to the map - not sure if this is how to do it since it's another special case 
        // to add to the page proxy builder
		//}

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
