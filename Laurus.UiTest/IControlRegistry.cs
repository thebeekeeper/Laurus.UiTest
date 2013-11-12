using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest
{
	public interface IControlRegistry
	{
		T GetControl<T>(SelectorBase selector) where T : IBaseControl;
		object GetControl(Type controlType, SelectorBase selector);
		object GetControl(Type controlType, ILocator locator);

		void RegisterControl<TControl, TImpl>();
	}
}
