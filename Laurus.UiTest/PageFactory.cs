using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest
{
	public class PageFactory
	{
        public PageFactory(INativeLocatorFactory nativeLocators, IControlRegistry controlRegistry)
		{
			_locators = nativeLocators;
			_controlRegistry = controlRegistry;
		}

        public T GetPage<T>() where T : IPage
		{
			var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
			var pageMap = types.Where(x => typeof(PageMap<T>).IsAssignableFrom(x)).FirstOrDefault();
			if (pageMap == default(Type))
			{
				throw new MapNotFoundException(String.Format("Map not found for page {0}", typeof(T).Name));
			}
			var mapInstance = (PageMap<T>)Activator.CreateInstance(pageMap);

            // build a proxy class for T
            // which has the MapFor<T> in it
			var proxy = new PageProxy<T>(mapInstance, _locators, _controlRegistry);
			return (T)proxy.GetTransparentProxy();
        }

		private readonly INativeLocatorFactory _locators;
		private readonly IControlRegistry _controlRegistry;
	}

    public class MapNotFoundException : Exception
	{
		public MapNotFoundException(string message)
			: base(message)
		{ }
	}
}
