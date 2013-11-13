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
		[Locator(Name = "q")]
		IEditable SearchBox { get; set; }

		[Locator(Name = "btnK")]
		IClickable SearchButton { get; set; }
    }
}
