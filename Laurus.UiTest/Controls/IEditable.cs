﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Controls
{
	public interface IEditable : IBaseControl
	{
		string Text { get; set; }
	}
}
