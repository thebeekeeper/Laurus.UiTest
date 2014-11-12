using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest.WebDriver.Util
{
	public class Request
	{
		public string HttpMethod { get; set; }
		public Uri Uri { get; set; }
	}

	public class RequestBuilder : IRequestBuilder
	{
		public RequestBuilder(string host, string session)
		{
			_sessionUri = String.Format("{0}/wd/hub/session/{1}", host, session);
		}
		//public static void StartSession(this HttpWebRequest request)
		//{
		//	request.Method = "GET";
		//	request.Accept = "application/json";
		//	var response = request.GetResponse();
		//	Console.WriteLine(response.ToString());
		//}

		//public static HttpWebRequest Get(this HttpWebRequest request, string url)
		//{
		//	return request;
		//}

		//public static Request Get(this Request request, string url)
		//{
		//	request.HttpMethod = "GET";
		//	request.Uri = new Uri(url);
		//	return request;
		//}

		//public static Request Post(this Request request, string url)
		//{
		//	request.HttpMethod = "POST";
		//	request.Uri = new Uri(url);
		//	return request;
		//}

		//public static Request WithBody<T>(this Request request, T body, string contentType)
		//{
		//	return request;
		//}

		//public static Request WithBody<T>(this Request request, T body)
		//{
		//	return WithBody<T>(request, body, "application/json");
		//}

		//public static void Send(this Request req)
		//{
		//	var r = HttpWebRequest.Create(req.Uri);
		//	r.GetResponse();
		//}
		void IRequestBuilder.Post(string queryString)
		{
			var request = (HttpWebRequest)HttpWebRequest.Create(String.Format("{0}/{1}", _sessionUri, queryString));
			request.Accept = "application/json";
			request.Method = "POST";
			request.ContentType = "application/json";
			var resp = (HttpWebResponse)request.GetResponse();
		}
		void IRequestBuilder.Post<T>(string queryString, T postBody)
		{
			var request = (HttpWebRequest)HttpWebRequest.Create(String.Format("{0}/{1}", _sessionUri, queryString));
			request.Accept = "application/json";
			request.Method = "POST";
			request.ContentType = "application/json";
			using (var bodyWriter = new StreamWriter(request.GetRequestStream()))
			{
				var b = Json.Encode(postBody);
				bodyWriter.Write(b);
				bodyWriter.Flush();
			}
			var resp = (HttpWebResponse)request.GetResponse();
		}

		TResponse IRequestBuilder.Post<TResponse, TRequest>(string queryString, TRequest postBody)
		{
			var request = (HttpWebRequest)HttpWebRequest.Create(String.Format("{0}/{1}", _sessionUri, queryString));
			request.Accept = "application/json";
			request.Method = "POST";
			request.ContentType = "application/json";
			using (var bodyWriter = new StreamWriter(request.GetRequestStream()))
			{
				var b = Json.Encode(postBody);
				bodyWriter.Write(b);
				bodyWriter.Flush();
			}
			var resp = (HttpWebResponse)request.GetResponse();
			TResponse result = default(TResponse);
			using (var reader = new StreamReader(resp.GetResponseStream()))
			{
				var json = reader.ReadToEnd();
				result = Json.Decode<TResponse>(json);
			}
			return result;
		}

        T IRequestBuilder.Get<T>(string queryString)
		{
			var request = (HttpWebRequest)HttpWebRequest.Create(String.Format("{0}/{1}", _sessionUri, queryString));
			request.Accept = "application/json";
			request.Method = "GET";
			request.ContentType = "application/json";
			var resp = (HttpWebResponse)request.GetResponse();
            var result = default(StatusResponse);
            using(var reader = new StreamReader(resp.GetResponseStream()))
			{
				var json = reader.ReadToEnd();
				result = Json.Decode<StatusResponse>(json);
			}
			return (T)Convert.ChangeType(result.value, typeof(T));
		}

		void IRequestBuilder.Send(string queryString)
		{
			throw new NotImplementedException();
		}

		private string _sessionUri;
	}
}
