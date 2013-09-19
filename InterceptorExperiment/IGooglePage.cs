using Laurus.UiTest;
using Laurus.UiTest.Controls;
using Laurus.UiTest.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorExperiment
{
	public interface IGooglePage : IPage
	{
		[Locator("q")]
		IEditable SearchBox { get; set; }
	}

	//public class GooglePage
	//{
	//	[Name("q")]
	//	public IEditable SearchBox { get; set; }
	//}

	public class GooglePage2
	{
		[Name("q")]
		public virtual Editable SearchBox { get; set; }
	}

	public class Editable
	{
		public virtual string Text { get; set; }
	}
}
