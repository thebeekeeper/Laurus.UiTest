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
		object GetControl(Type controlType, ILocator locator);

		void RegisterControl<TControl, TImpl>();

        /// <summary>
        /// Registers all controls in the current directory
        /// </summary>
		void RegisterLocalControls();
	}
}
