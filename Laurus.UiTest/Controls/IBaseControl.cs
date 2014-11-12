using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Controls
{
	public interface IBaseControl
	{
		void Find(ILocator locator);

		bool IsVisible();
		bool IsEnabled();
	}
}
