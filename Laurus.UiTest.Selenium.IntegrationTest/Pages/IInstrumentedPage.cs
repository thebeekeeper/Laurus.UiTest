using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.Selenium.IntegrationTest.Pages
{
	public interface IInstrumentedPage : IPage
	{
		IEditable Name { get; }
		IEditable Age { get; }
		IClickable Submit { get; }
		IStatic StaticSpan { get; }
		IStatic Result { get; }
	}

    public class InstrumentedPageMap : PageMap<IInstrumentedPage>
	{
        public InstrumentedPageMap() : base("data-qa")
		{
			AddToMap(x => x.StaticSpan, LocatorKey.Name, "uninstrumented");
			AddToMap(x => x.Result, LocatorKey.Id, "result");
		}
	}
}
