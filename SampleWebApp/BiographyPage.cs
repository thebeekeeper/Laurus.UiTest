using Laurus.UiTest;
using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApp
{
	public interface IBiographyPage : IPage
	{
		IClickable NextButton { get; set; }

		IEditable Name { get; set; }

		IEditable Age { get; set; }

		IEditable Relationship { get; set; }

		IEditable Result { get; set; }

		//[Locator("Id = item{0}")]
		IList<IStatic> ListItems { get; set; }
	}

    public class BioMap : PageMap<IBiographyPage>
	{
        public BioMap()
		{
			AddToMap(x => x.NextButton, "Name", "biographyNext");
			AddToMap(x => x.Name, "Name", "nameEdit");
			AddToMap(x => x.Age, "Name", "ageEdit");
			AddToMap(x => x.Relationship, "Name", "relationEdit");
			AddToMap(x => x.Result, "Name", "result");
            // need an overload for collections
			//AddToMap(x => x.ListItems, "Id", "item{0}");
		}
	}
}
