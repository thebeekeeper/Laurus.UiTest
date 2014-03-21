using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class NewMapSample : Page
	{
		IClickable MyButton { get; set; }

		public NewMapSample()
		{
			ControlExtensions.FindWith<Page, BaseControl>(c => c.Elements.Where(x => x.TagName.Equals("a")).First());
			var smf = new SampleMapFor();
			smf.AddLocator(c => c.Elements.Where(x => x.TagName.Equals("a")).First());
		}
	}

	public static class ControlExtensions
	{
		public static TControl FindWith<TPage, TControl>(Expression<Func<TPage, TControl>> selector) where TPage : Page
		{
			throw new NotImplementedException();
		}
	}

	public class SampleMapFor : MapFor<NewMapSample>
	{
		public void AddLocator<TControl>(Expression<Func<NewMapSample, TControl>> e)
		{
			Console.WriteLine(e.Name);
		}

		void MapFor<NewMapSample>.AddLocator<TControl>(Expression<Func<NewMapSample, TControl>> e)
		{
			throw new NotImplementedException();
		}
	}

    public interface MapFor<TPage>
	{
		void AddLocator<TControl>(Expression<Func<TPage, TControl>> e);
	}

	public class Page
	{
		public IEnumerable<BaseControl> Elements { get; set; }
	}

	public class BaseControl
	{
		public string TagName { get; set; }
		public string Css { get; set; }
		public string Text { get; set; }

        public void Click()
		{
			throw new NotImplementedException();
		}
	}


}
