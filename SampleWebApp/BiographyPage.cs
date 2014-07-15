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
		IEnumerable<IStatic> ListItems { get; set; }
		ISelect PetPreference { get; }
		IClickable LinkWithText { get; }
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
			//AddToMap(x => x.ListItems, "Id", new[] { "item0", "item1", "item2" });
			AddToMap(x => x.ListItems, "Id", i => "item" + i.ToString());
			AddToMap(x => x.PetPreference, LocatorKey.Id, "pet-prefs");
			AddToMap(x => x.LinkWithText, LocatorKey.Id, "linkWithText");
		}
	}
}
