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
		IClickable ResultStats { get; set; }
	}

    public class ResultsMap : PageMap<IResultsPage>
	{
		public ResultsMap()
		{
			AddToMap(x => x.ResultStats, "Name", "resultStats");
		}
	}
}
