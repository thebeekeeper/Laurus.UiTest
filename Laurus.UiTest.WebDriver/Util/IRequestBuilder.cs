using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.WebDriver.Util
{
	public interface IRequestBuilder
	{
		void Post(string queryString);
		void Post<T>(string queryString, T postBody);
		TResponse Post<TResponse, TRequest>(string queryString, TRequest postBody);
		T Get<T>(string queryString);
		void Send(string queryString);
	}
}
