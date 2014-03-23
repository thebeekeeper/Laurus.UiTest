using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest
{
	public class PageFactory
	{
        /// <summary>
        /// Looks in all types loaded in the current AppDomain for page maps
        /// </summary>
        /// <param name="nativeLocators"></param>
        /// <param name="controlRegistry"></param>
        public PageFactory(INativeLocatorFactory nativeLocators, IControlRegistry controlRegistry) : this(nativeLocators, controlRegistry, x => true)
		{ }

        /// <summary>
        /// Only looks in types that match the given predicate to determine what page maps to use.  Useful
		/// for test suites that run against multiple platforms and need multiple page map versions
        /// </summary>
        /// <param name="nativeLocators"></param>
        /// <param name="controlRegistry"></param>
        /// <param name="mapPredicate"></param>
        public PageFactory(INativeLocatorFactory nativeLocators, IControlRegistry controlRegistry, Func<Type, bool> mapPredicate)
		{
			_locators = nativeLocators;
			_controlRegistry = controlRegistry;
			_mapPredicate = mapPredicate;
		}

        public T GetPage<T>() where T : IPage
		{
			var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
			var pageMap = types.Where(x => typeof(PageMap<T>).IsAssignableFrom(x)).Where(_mapPredicate).FirstOrDefault();
			if (pageMap == default(Type))
			{
				throw new MapNotFoundException(typeof(T));
			}
			var mapInstance = (PageMap<T>)Activator.CreateInstance(pageMap);

            // build a proxy class for T
            // which has the MapFor<T> in it
			var proxy = new PageProxy<T>(mapInstance, _locators, _controlRegistry);
			return (T)proxy.GetTransparentProxy();
        }

		private readonly INativeLocatorFactory _locators;
		private readonly IControlRegistry _controlRegistry;
		private readonly Func<Type, bool> _mapPredicate;
	}
}
