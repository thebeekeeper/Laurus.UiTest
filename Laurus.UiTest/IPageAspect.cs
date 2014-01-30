using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest
{
	public interface IPageAspect
	{
		void BeforeControl(Type pageType);

		void AfterControl(Type pageType);
	}
}
