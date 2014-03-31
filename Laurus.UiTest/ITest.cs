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
        // what was this for???
		//string TargetApplication { get; set; }

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
		/// Takes a screenshot of the app under test
		/// </summary>
		/// <param name="path">Full path of the file to save to</param>
		void TakeScreenshot(string path);

		/// <summary>
		/// Executes an arbirary script on the page under test
		/// </summary>
		/// <param name="script"></param>
		/// <param name="parameters"></param>
		void RunScript(string script, Dictionary<string, object> parameters);

		/// <summary>
		/// Sets the device orientation to the specified value if the device under
		/// test supports rotation
		/// </summary>
		/// <param name="orientation"></param>
		void SetOrientation(Orientation orientation);

		/// <summary>
		/// Ends the tests and closes any associated target app/browser
		/// </summary>
		void Quit();
	}
}
