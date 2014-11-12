using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Laurus.UiTest.WebDriver.Util
{
	public class Json
	{
		public static string Encode<T>(T entity)
		{
			var serializer = new DataContractJsonSerializer(entity.GetType());
			var stream = new MemoryStream();
			serializer.WriteObject(stream, entity);
			var encoded = Encoding.UTF8.GetString(stream.ToArray());
			stream.Close();
			return encoded;
		}

        public static T Decode<T>(string json)
		{
			var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
			var serializer = new DataContractJsonSerializer(typeof(T));
			var rval = (T)serializer.ReadObject(stream);
			stream.Close();
			return rval;
		}
	}
}
