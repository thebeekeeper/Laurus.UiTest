using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.Selenium.IntegrationTest.Pages
{
	public interface IBiographyPage2 : IPage
	{
		IClickable NextButton { get; set; }
		IEditable Name { get; set; }
		IEditable Age { get; set; }
		IEditable Relationship { get; set; }
		IEditable Result { get; set; }
		ICollection<IStatic> ListItems { get; set; }
		ISelect PetPreference { get; }
	}
	public class BiographyPageMapDefaults : PageMap<IBiographyPage2>
	{
        // setting default locator key 
        public BiographyPageMapDefaults() : base("Name")
		{
			AddToMap(x => x.NextButton, "biographyNext");
			AddToMap(x => x.Name, "nameEdit");
			AddToMap(x => x.Age, "ageEdit");
			AddToMap(x => x.Relationship, "relationEdit");
			AddToMap(x => x.Result, "result");
			AddToMap(x => x.ListItems, "Id", new[] { "item0", "item1" });
			AddToMap(x => x.PetPreference, LocatorKey.Id, "pet-prefs");
		}
	}
}
