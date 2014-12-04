using Laurus.UiTest.WebDriver.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.WebDriver
{
	public class Mouse
	{
        public Mouse(IRequestBuilder request)
		{
			_request = request;
		}

		public void Click(MouseButton button = MouseButton.Left) 
		{
			_request.Post<MousePressRequest>("/click", new MousePressRequest() { button = (int)button });
		}

		public void Press(int button) 
		{
			_request.Post<MousePressRequest>("/buttondown", new MousePressRequest() { button = (int)button });
		}

		public void Release(int button) 
		{ 
			_request.Post<MousePressRequest>("/buttonup", new MousePressRequest() { button = (int)button });
		}

		public void DoubleClick(int button) 
		{ 
			_request.Post<MousePressRequest>("/doubleclick", new MousePressRequest() { button = (int)button });
		}

		private IRequestBuilder _request;
	}

    public class MousePressRequest
	{
		public int button { get; set; }
	}
}
