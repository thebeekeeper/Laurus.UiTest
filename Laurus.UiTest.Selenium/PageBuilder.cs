//using Laurus.UiTest.Locators;
//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium;
//using Laurus.UiTest.Controls;

//namespace Laurus.UiTest.Selenium
//{
//	// TODO: shouldn't be public - only get pages through ITest
//	public class PageBuilder : IPageBuilder
//	{
//		public PageBuilder(IWebDriver driver)
//		{
//			_driver = driver;
//		}

//		T IPageBuilder.GetPage<T>()
//		{
//			dynamic page = new ExpandoObject();
//			var allControls = typeof(T).GetProperties().Where(t => t.PropertyType.GetInterface("IBaseControl") != null);
//			foreach (var control in allControls)
//			{
//				var nameAttribute = control.GetCustomAttributes(typeof(NameAttribute), false).FirstOrDefault();
//				if(nameAttribute != default(object))
//				{
//					var name = ((NameAttribute)nameAttribute).Value;
//					var finder = By.Name(name);
//					var controlInstance = FindControlImplementation(control.PropertyType, _driver);
//					controlInstance.Find(new NameSelector(name));
//					((IDictionary<string, object>)page).Add(control.Name, controlInstance);
//				}
//			}
//			return DynamicDuck.DynamicDuck.AsIf<T>(page);
//		}

//		private IBaseControl FindControlImplementation(Type controlType, IWebDriver driver)
//		{
//			// TODO: replace this with something that'll scale as more controls are added
//			if (controlType.Equals(typeof(IClickable)))
//				return (IBaseControl)Activator.CreateInstance(typeof(Clickable), new object[] { driver });
//			if (controlType.Equals(typeof(IEditable)))
//				return (IBaseControl)Activator.CreateInstance(typeof(Editable), new object[] { driver });

//			throw new Exception(String.Format("Control type {0} not implemented", controlType.Name));
//		}

//		private IWebDriver _driver;
//	}
//}
