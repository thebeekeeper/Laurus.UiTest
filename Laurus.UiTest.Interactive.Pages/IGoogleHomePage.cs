using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Interactive.Pages
{
    public interface IGoogleHomePage : IPage
    {
		IEditable SearchBox { get; set; }
		IClickable SearchButton { get; set; }
    }

	//public class GooglePageMap : IMapFor<IGoogleHomePage>
	//{
	//	void IMapFor<IGoogleHomePage>.Configure(PageMap<IGoogleHomePage> map)
	//	{
	//		map.AddToMap(x => x.SearchBox, "Name", "q");
	//		map.AddToMap(x => x.SearchButton, "Name", "btnQ");
	//	}

	//	string IMapFor<IGoogleHomePage>.LocatorFor(string property)
	//	{
	//		return _locators[property];
	//	}

	//	private Dictionary<string, string> _locators;
	//}
}
