﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.Selenium
{
	// TODO: this still seems pretty shabby
	public class SeleniumLocator : By, ILocator
	{
		public By By { get; set; }
	}

	public class ExpressionLocator 
	{
		public static SeleniumLocator Expression(string expr)
		{
			if (String.IsNullOrEmpty(expr))
			{
				throw new ArgumentOutOfRangeException("Expression is empty");
			}

			// simple expression parser - column=value
			var parts = expr.Split(new[] { '=' });
			var column = parts[0].ToLower().Trim();
			var value = parts[1].Trim();

			switch (column)
			{
				case "name":
					return new SeleniumLocator() { By = By.Name(value) };
				case "id":
					return new SeleniumLocator() { By = By.Id(value) };
				case "tagname":
					return new SeleniumLocator() { By = By.TagName(value) };
				case "text":
					return new SeleniumLocator() { By = By.PartialLinkText(value) };
				case "xpath":
					return new SeleniumLocator() { By = By.XPath(value) };
				case "css":
					return new SeleniumLocator() { By = By.CssSelector(value) };
				case "classname":
					return new SeleniumLocator() { By = By.ClassName(value) };
				default:
					throw new ArgumentException(String.Format("{0} is not a valid search criteria", column));
			}
		}
	}
}
