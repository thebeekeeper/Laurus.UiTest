using Laurus.UiTest.WebDriver.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.WebDriver
{
	public class Element
	{
        // Need the element id to identify it, and the session to send requests to
        public Element(IRequestBuilder request, int id)
		{
			_request = request;
			_id = id;
		}

		public void Click() 
		{ 
            var queryString = String.Format("element/{0}/click", _id);
			_request.Post(queryString);
		}

		public void Submit() 
		{
			var queryString = String.Format("element/{0}/submit", _id);
			_request.Post(queryString);
		}
		public string Text 
		{
			get
			{
				var queryString = String.Format("element/{0}/text", _id);
				var resp = _request.Get<string>(queryString);
				return resp;
			}
			private set { }
		}

        // figure out something about how these are different...
		public void SetValue(string value) { }
		public void SendKeys(string value) { }

		public void ClearText() 
		{
			var q = String.Format("element/{0}/clear", _id);
			_request.Post(q);
		}

		public bool Selected 
		{ 
			get
			{
				var q = String.Format("element/{0}/selected", _id);
				return _request.Get<bool>(q);
			}
			private set { }
		}

		public bool Enabled
		{
            get
			{
				var q = String.Format("element/{0}/enabled", _id);
				return _request.Get<bool>(q);
			}
			private set { }
		}

		public bool Displayed
		{
            get
			{
				var q = String.Format("element/{0}/displayed", _id);
				return _request.Get<bool>(q);
			}
			private set { }
		}

		public string Name
		{
			get
			{
				var q = String.Format("element/{0}/name", _id);
				var resp = _request.Get<string>(q);
				return resp;
			}
			private set { }
		}

        // this is an actual spec defined http method
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public Point Location
		{
            get
			{
				var q = String.Format("element/{0}/location", _id);
                // need a custom type here
				var s = _request.Get<string>(q);
				Console.Write(s);
				return new Point();
			}
			private set { }
		}
		// idgi: Determine an element's location on the screen once it has been scrolled into view.
		public object LocationInView { get; private set; }
		public object Size { get; private set; }
        public void PropertyName(string name)
		{
            //Query the value of an element's computed CSS property. The CSS property to query should be specified using the CSS property name, not the JavaScript property name (e.g. background-color instead of backgroundColor).
		}

		// /session/:sessionId/moveto
        public void MoveTo(int offsetX, int offsetY)
		{ }

		private IRequestBuilder _request;
		private int _id;
	}
}
