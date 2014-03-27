using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.Controls
{
	public interface ISelect : IBaseControl
	{
		string SelectedText { get; set; }
	}
}
