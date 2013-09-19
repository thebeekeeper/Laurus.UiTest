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
		[Locator("biographyNext")]
		IClickable NextButton { get; set; }

		[Locator("nameEdit")]
		IEditable Name { get; set; }

		[Locator("ageEdit")]
		IEditable Age { get; set; }

		[Locator("relationEdit")]
		IEditable Relationship { get; set; }

		[Locator("result")]
		IEditable Result { get; set; }
	}
}
