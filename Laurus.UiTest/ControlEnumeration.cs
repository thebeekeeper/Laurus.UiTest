using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest
{ 
    // if i implement this, do i actually have to intercept collections?
	public class ControlEnumeration<TControl> : IEnumerable<TControl> where TControl : IBaseControl
	{
		public ControlEnumeration(CollectionLocator locator, INativeLocatorFactory locatorFactory, IControlRegistry controlRegistry)
		{
			_enumerator = new ControlEnumerator<TControl>(locator, locatorFactory, controlRegistry);
		}

		IEnumerator<TControl> IEnumerable<TControl>.GetEnumerator()
		{
			return _enumerator;
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		private ControlEnumerator<TControl> _enumerator;
	}

    public class ControlEnumerator<TControl> : IEnumerator<TControl>
	{
        public ControlEnumerator(CollectionLocator locator, INativeLocatorFactory locatorFactory, IControlRegistry controlRegistry)
		{
			_locator = locator;
			_converter = locatorFactory;
			_controlRegistry = controlRegistry;
			_currentIndex = 0;
		}

		public TControl Current
		{
			get 
			{
				var l = _locator.Values.ElementAt(_currentIndex);
				var nativeLocator = _converter.Build(new Locator() { Key = _locator.Key, Value = l });
				var nativeControl = _controlRegistry.GetControl(typeof(TControl), nativeLocator);
				return (TControl)nativeControl;
			}
		}

		public void Dispose()
		{
			_currentIndex = 0;
		}

		object System.Collections.IEnumerator.Current
		{
			get { throw new NotImplementedException(); }
		}

		public bool MoveNext()
		{
            // TODO: check if the next control exists
			return true;
		}

		public void Reset()
		{
			_currentIndex = 0;
		}

		private int _currentIndex;
		private readonly INativeLocatorFactory _converter;
		private readonly IControlRegistry _controlRegistry;
		private CollectionLocator _locator;
	}
}
