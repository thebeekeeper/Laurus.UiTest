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
		[Name("nameEdit")]
		public IEditable Name {get;set;}

		[Name("Age")]
		public IEditable Age { get; set; }

		[Name("relationEdit")]
		public IEditable RelationToInjured { get; set; }

		[Name("biographyNext")]
		public IClickable Next { get; set; }
	}
}
