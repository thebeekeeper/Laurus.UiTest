using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest
{
	public interface ITest
	{
		/// <summary>
		/// Can be a file path or URI
		/// </summary>
		string TargetApplication { get; set; }

		/// <summary>
		/// Builds a page of the given type
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		T GetPage<T>() where T : IPage;

		/// <summary>
		/// Navigates to the given target
		/// </summary>
		/// <param name="target"></param>
		void Navigate(string target);

		/// <summary>
		/// Ends the tests and closes any associated target app/browser
		/// </summary>
		void Quit();
	}
}
