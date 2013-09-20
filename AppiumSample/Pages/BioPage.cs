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
		[Locator(Name = "nameEdit")]
		public IEditable Name {get;set;}

		[Locator(Name = "Age")]
		public IEditable Age { get; set; }

		[Locator(Name = "relationEdit")]
		public IEditable RelationToInjured { get; set; }

		[Locator(Name = "biographyNext")]
		public IClickable Next { get; set; }
	}
}
