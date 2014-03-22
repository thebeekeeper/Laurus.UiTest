using Laurus.UiTest;
using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSample.Pages
{
	public class BioPage : IPage
	{
		public IEditable Name {get;set;}
		public IEditable Age { get; set; }
		public IEditable RelationToInjured { get; set; }
		public IClickable Next { get; set; }
	}

    public class BioPageMap : PageMap<BioPage>
	{
        public BioPageMap()
		{
			AddToMap(x => x.Name, "Name", "nameEdit");
			AddToMap(x => x.Age, "Name", "Age");
			AddToMap(x => x.RelationToInjured, "Name", "relationEdit");
			AddToMap(x => x.Next, "Name", "biographyNext");
		}
	}
}
