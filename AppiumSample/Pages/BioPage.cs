using Laurus.UiTest;
using Laurus.UiTest.Controls;
using Laurus.UiTest.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSample.Pages
{
	public class BioPage : IPage
	{
		[Locator("nameEdit")]
		public IEditable Name {get;set;}

		[Locator("Age")]
		public IEditable Age { get; set; }

		[Locator("relationEdit")]
		public IEditable RelationToInjured { get; set; }

		[Locator("biographyNext")]
		public IClickable Next { get; set; }
	}
}
