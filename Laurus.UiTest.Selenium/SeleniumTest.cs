using Laurus.UiTest.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;

namespace Laurus.UiTest.Selenium
{
	public class SeleniumTest : ITest
	{
        public SeleniumTest(Dictionary<string, object> parameters, StartupParameters startupParams, Func<Type, bool> mapSelector)
		{
			var desiredCaps = new DesiredCapabilities(parameters);

			switch (startupParams.BrowserType)
			{
				case BrowserType.Firefox:
					_driver = new FirefoxDriver();
					break;
				case BrowserType.Chrome:
					_driver = new ChromeDriver();
					break;
				case BrowserType.PhantomJs:
					try
					{
						_driver = new PhantomJSDriver();
					}
                    catch(Exception e)
					{
						Console.WriteLine(e.Message);
					}
					break;
				case BrowserType.Remote:
					try
					{
						_driver = new ScreenshotRemoteWebDriver(new Uri(startupParams.RemoteHost), desiredCaps, TimeSpan.FromMinutes(5));
					}
                    catch(Exception e)
					{
						Console.WriteLine(e.Message);
					}
					break;
				default:
					throw new Exception("Browser type not found");
			}
			_driver.Manage().Timeouts().ImplicitlyWait(startupParams.ImplicitWait);
			var controlReg = new ControlRegistry(new[] { _driver }) as IControlRegistry;
			controlReg.RegisterLocalControls();
			_pageFactory = new PageFactory(new LocatorFactory(), controlReg, mapSelector);
		}

		public SeleniumTest(Dictionary<string, object> parameters, StartupParameters startupParams)
			: this(parameters, startupParams, x => true)
		{ }

		T ITest.GetPage<T>()
		{
			return _pageFactory.GetPage<T>();
		}

		void ITest.Navigate(string target)
		{
			if (target.Equals("back"))
			{
				_driver.Navigate().Back();
				return;
			}
			if (target.StartsWith("http") || target.StartsWith("file"))
			{
				_driver.Navigate().GoToUrl(target);
				return;
			}
			var current = new Uri(_driver.Url);
			var u = String.Format("{0}://{1}{2}", current.Scheme, current.Host, target);
			var destination = new Uri(u, UriKind.Absolute);
			_driver.Navigate().GoToUrl(destination.AbsoluteUri);
		}

		void ITest.TakeScreenshot(string file)
		{
			var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
			screenshot.SaveAsFile(file, System.Drawing.Imaging.ImageFormat.Png);
		}

        string ITest.TakeScreenshot()
		{
			var file = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
			((ITest)this).TakeScreenshot(file);
			return file;
		}

		void ITest.RunScript(string script, Dictionary<string, object> parameters)
		{
			var jsExecutor = (IJavaScriptExecutor)_driver;
			jsExecutor.ExecuteScript(script, parameters);
		}

		void ITest.SetOrientation(Orientation orientation)
		{
			var rotatable = _driver as IRotatable;
			if (rotatable != null)
			{
				if (orientation == Orientation.Landscape)
					rotatable.Orientation = ScreenOrientation.Landscape;
				else
					rotatable.Orientation = ScreenOrientation.Portrait;
			}
		}

        string ITest.Source()
		{
			return _driver.PageSource;
		}

		void ITest.Quit()
		{
			_driver.Quit();
		}

		private readonly IWebDriver _driver;
		private readonly PageFactory _pageFactory;
	}
}
