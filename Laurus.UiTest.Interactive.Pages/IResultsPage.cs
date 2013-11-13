using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Interactive.Pages
{
	public interface IResultsPage : IPage
	{
		[Locator(Name = "resultStats")]
		IClickable ResultStats { get; set; }
	}
}
