using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest
{
	public static class MethodInfoExtensions
	{
		public static bool IsGetter(this MethodInfo methodInfo)
		{
			return methodInfo.Name.StartsWith("get_");
		}

		public static bool IsSetter(this MethodInfo methodInfo)
		{
			return methodInfo.Name.StartsWith("set_");
		}
	}
}
