using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Laurus.UiTest.Controls;
using Laurus.UiTest.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InterceptorExperiment
{
	public class SampleTests
	{
		[Fact]
		public void CanBuildClickable()
		{
			var container = new WindsorContainer();
			//container.Register(Component.For<GooglePage>());
			//container.Register(Component.For<GooglePage2>());
			//container.Register(Component.For<GooglePage2>().Interceptors<PageInterceptor>().LifestyleTransient());
			container.Register(Component.For<IGooglePage>().Interceptors(InterceptorReference.ForType<PageInterceptor>()).Last);
			//container.Register(Component.For<IClickable>().Interceptors(InterceptorReference.ForType<ControlInterceptor>()).Last);
			//container.Register(Component.For<IEditable>().Interceptors(InterceptorReference.ForType<ControlInterceptor>()).Last);
			//container.Register(Component.For<Editable>().Interceptors(InterceptorReference.ForType<ControlInterceptor>()).Last);
			//container.Register(Component.For<ControlInterceptor>());
			container.Register(Component.For<PageInterceptor>());
			IWebDriver driver = new FirefoxDriver();
			driver.Navigate().GoToUrl("http://www.google.com");
			container.Register(Component.For<IWebDriver>().Instance(driver));

			var page = container.Resolve<IGooglePage>();
			page.SearchBox.Text = "i'm laura nauth, BITCH";

			//var editable = container.Resolve<IEditable>();
			//editable.Find(new NameSelector("q"));
			//editable.Text = "i'm laura nauth, BITCH";
		}
	}
}
