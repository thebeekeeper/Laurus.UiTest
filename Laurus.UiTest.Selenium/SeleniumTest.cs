using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
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

namespace Laurus.UiTest.Selenium
{
	public class SeleniumTest : ITest
	{
		string ITest.TargetApplication { get; set; }

		public SeleniumTest(Dictionary<string, object> parameters, StartupParameters startupParams)
		{
			_container = new WindsorContainer();

			// TODO: putting the controls in windsor gives some weird null ref exception when resolving a page
			//_container.Register(Component.For<IEditable>().ImplementedBy<Editable>().LifestyleTransient());
			//_container.Register(Component.For<IClickable>().ImplementedBy<Clickable>().LifestyleTransient());

			// need to register all types that inherit from IPage with interceptor
			_container.Register(
				Types.FromAssemblyInDirectory(new AssemblyFilter(".", "*.dll"))
				.Where(t => typeof(IPage).IsAssignableFrom(t))
				.Configure(component => component.LifeStyle.Transient.Interceptors<PageInterceptor>()));
			_container.Register(Component.For<PageInterceptor>());
			_container.Register(Component.For<ILocatorFactory>().ImplementedBy<LocatorFactory>());

			var desiredCaps = new DesiredCapabilities(parameters);

			switch (startupParams.BrowserType)
			{
				case BrowserType.Firefox:
					_driver = new FirefoxDriver();
					break;
				case BrowserType.Chrome:
					_driver = new ChromeDriver();
					break;
				case BrowserType.Remote:
					_driver = new ScreenshotRemoteWebDriver(new Uri(startupParams.RemoteHost), desiredCaps, TimeSpan.FromMinutes(5));
					break;
				default:
					throw new Exception("Browser type not found");
			}
			_driver.Manage().Timeouts().ImplicitlyWait(startupParams.ImplicitWait);
			_container.Register(Component.For<IWebDriver>().Instance(_driver).LifestyleSingleton());
			IControlRegistry controlReg = new ControlRegistry(new object[] { _driver });
			controlReg.RegisterControl<IEditable, Editable>();
			controlReg.RegisterControl<IClickable, Clickable>();
			controlReg.RegisterControl<IStatic, Static>();
			_container.Register(Component.For<IControlRegistry>().Instance(controlReg).LifestyleSingleton());

			// TODO: make this work
			((IRotatable)_driver).Orientation = ScreenOrientation.Landscape;
		}

		T ITest.GetPage<T>()
		{
			return _container.Resolve<T>();
		}

		void ITest.Navigate(string target)
		{
			if (target.Equals("back"))
				_driver.Navigate().Back();
			else
			{
				_driver.Navigate().GoToUrl(target);
			}
		}

		void ITest.TakeScreenshot(string file)
		{
			var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
			screenshot.SaveAsFile(file, System.Drawing.Imaging.ImageFormat.Png);
		}

		void ITest.RunScript(string script, Dictionary<string, object> parameters)
		{
			var jsExecutor = (IJavaScriptExecutor)_driver;
			jsExecutor.ExecuteScript(script, parameters);
		}

		void ITest.Quit()
		{
			_driver.Quit();
		}

		private readonly IWebDriver _driver;
		private readonly IWindsorContainer _container;
	}
}
