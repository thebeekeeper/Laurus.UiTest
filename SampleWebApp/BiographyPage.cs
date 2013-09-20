using Laurus.UiTest;
using Laurus.UiTest.Controls;
using Laurus.UiTest.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApp
{
	public interface IBiographyPage : IPage
	{
		[Locator(Name = "biographyNext")]
		IClickable NextButton { get; set; }

		[Locator(Name = "nameEdit")]
		IEditable Name { get; set; }

		[Locator(Name = "ageEdit")]
		IEditable Age { get; set; }

		[Locator(Name = "relationEdit")]
		IEditable Relationship { get; set; }

		[Locator(Name = "result")]
		IEditable Result { get; set; }
	}
}
