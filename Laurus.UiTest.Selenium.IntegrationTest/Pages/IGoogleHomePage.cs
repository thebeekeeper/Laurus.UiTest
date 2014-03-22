using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium.IntegrationTest.Pages
{
    public interface IGoogleHomePage : IPage
    {
		IEditable SearchBox { get; set; }
		IClickable SearchButton { get; set; }
    }

    public class GoogleMap : PageMap<IGoogleHomePage>
	{
        public GoogleMap()
		{
			AddToMap(x => x.SearchBox, LocatorKey.Name, "q");
			AddToMap(x => x.SearchButton, LocatorKey.Name, "btnQ");
		}
	}
}
