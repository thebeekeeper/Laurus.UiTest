using Laurus.UiTest.WebDriver.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.WebDriver
{
    public class Session
    {
        public Session(string sessionId, string host)
		{
			_sessionId = sessionId;
			_sessionUri = String.Format("{0}/wd/hub/session/{1}", host, sessionId);
			_request = new RequestBuilder(host, sessionId);
			Browser = new Browser(_request);
		}

        // set this in the constructor?
		public Mouse Mouse { get; private set; }
		public Finger Finger { get; private set; }
		public Browser Browser { get; private set; }


		public void Delete()
		{
			var request = (HttpWebRequest)HttpWebRequest.Create(_sessionUri);
			request.Accept = "application/json";
			request.Method = "DELETE";
			var resp = (HttpWebResponse)request.GetResponse();
			Console.WriteLine(resp.StatusCode);
		}

		public void SessionCapabilities() { }
		public int Timeout { private get; set; }
		public int AsyncTimeout { private get; set; }
		public int ImplicitWait { private get; set; }
		public object WindowHandle { get; private set; }
		public object AvailableWindowHandles { get; private set; }


		public Element Locate(LocatorCriteria locator) 
		{
			var status = _request.Post<LocatorResponse, LocatorRequest>("/element", new LocatorRequest() { @using = locator.Criteria, value = locator.Value }).value;
            // value comes back like ELEMENT=0
			var id = Int32.Parse(status.ELEMENT);
			return new Element(_request, id);
		}

		public IEnumerable<Element> LocateObjects(object locator) { return null; }

        // these should go somewhere else
		//public string AlertText { get; set; }
		//public void AcceptAlert() { }
		//public void CancelAlert() { }

        // i probably don't need this
		private string _sessionId;
		private string _sessionUri;
		private IRequestBuilder _request;
    }

    public class LocatorRequest
	{
		public string @using { get; set; }
		public string value { get; set; }
	}

    public class LocatorResponse
	{
		public LocatorValue value { get; set; }
	}
    public class LocatorValue
	{
        public string ELEMENT {get;set;}
    }
}
