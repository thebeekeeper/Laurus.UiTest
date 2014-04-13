using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.Selenium.IntegrationTest.Pages
{
	public interface ILoginPage : IPage
	{
		ILoginBox Login { get; }
		IStatic Header { get; }
	}

    public class LoginPageMap : PageMap<ILoginPage>
	{
        public LoginPageMap()
		{
			AddToMap(x => x.Header, LocatorKey.Id, "header");
			//AddToMap(x => x.Login, LocatorKey.Id, "login-box");
		}
	}

    public interface ILoginBox : IPage
	{
		IEditable Username { get; }
		IEditable Password { get; }
		IClickable Submit { get; }
	}

    public class LoginBoxMap : PageMap<ILoginBox>
	{
        public LoginBoxMap()
		{
			AddToMap(x => x.Username, LocatorKey.Id, "username");
			AddToMap(x => x.Username, LocatorKey.Id, "password");
			AddToMap(x => x.Submit, LocatorKey.Id, "submit-login");
		}
	}
}
