using Laurus.UiTest.WebDriver.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.WebDriver
{
	public class Browser
	{
        public Browser(IRequestBuilder request)
		{
			_request = request;
		}

		public IDictionary<string, string> LocalStorage { get; private set; }
		public IDictionary<string, string> SessionStorage { get; private set; }
		public void Forward() { }
		public void Back() { }
		public void Refresh() { }
		public void ExecuteScript(string javascript) { }
		public byte[] TakeScreenshot() { return null; }
		public string PageSource { get; private set; }
		public string PageTitle { get; private set;}
		public Uri Uri 
		{ 
			get
			{
				return new Uri(_request.Get<string>("/url"));
			}
			set
			{
				_request.Post("/url", new Navigation() { url = value.ToString() });
			}
		}
		public object Orientation { get; set; }

		private IRequestBuilder _request;
	}
}
