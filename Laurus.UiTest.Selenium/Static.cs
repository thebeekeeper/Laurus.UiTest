﻿using Laurus.UiTest.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	public class Static : BaseControl, IStatic
	{
		public Static(IWebDriver driver)
			: base(driver)
		{ }

		string IStatic.Text
		{
			//get { return GetNative().Text + GetNative().GetAttribute("name"); }
			//get { return GetNative().Text; }
			get
			{
				var t = GetNative().Text;
				if (String.IsNullOrEmpty(t))
					t = GetNative().GetAttribute("name");
				return t;
			}
		}
	}
}
