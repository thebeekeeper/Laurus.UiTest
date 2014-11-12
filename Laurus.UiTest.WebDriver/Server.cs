using Laurus.UiTest.WebDriver.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Laurus.UiTest.WebDriver
{
	public class Server
	{
        public static Session StartSession(string uri)
		{
			var id = string.Empty;
			var request = (HttpWebRequest)HttpWebRequest.Create(uri + "/wd/hub/session");
			request.Accept = "application/json";
			request.ContentType = "application/json";
			request.Method = "POST";
			var bodyWriter = new StreamWriter(request.GetRequestStream());
			var b = Json.Encode(new SessionStartup() { desiredCapabilities = new DesiredCapabilities() { browserName = "firefox" } });
			bodyWriter.Write(b);
			bodyWriter.Flush();
			var resp = (HttpWebResponse)request.GetResponse();
			var reader = new StreamReader(resp.GetResponseStream());
			var response = reader.ReadToEnd();
			Console.WriteLine(response);
			var sessionId = Json.Decode<SessionStartupResponse>(response).sessionId;
			return new Session(sessionId, uri);
		}

        public static void ServerStatus()
		{ }

        public static void ActiveSessions()
		{ }
	}
}
