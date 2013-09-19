using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Controls
{
	public interface IBaseControl
	{
		// TODO: don't return anything from this
		void Find(SelectorBase selector);
	}
}
