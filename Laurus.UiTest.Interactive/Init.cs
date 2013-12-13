			ITest test = new SeleniumTest
			(
				new Dictionary<string, object>()
				{
					{ "browserName", "" },
					{ "version", "6.0" }, 
					{ "app", "/Users/administrator/savo.zip" },
					{ "platform", "Mac" },
					{ "device", "iPhone" },
				},
				new StartupParameters()
				{
					RemoteHost = "http://10.1.7.97:4723/wd/hub",
					BrowserType = Laurus.UiTest.BrowserType.Remote,
					ImplicitWait = TimeSpan.FromSeconds(10)
				}
			);
