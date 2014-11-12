using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laurus.UiTest.WebDriver
{
	public class Finger
	{
        public Finger(Session session)
		{ }

		public void Tap(int x, int y) { }
		public void DoubleTap(int x, int y) { }
		public void Down(int x, int y) { }
		public void Up(int x, int y) { }
		public void MoveTo(int x, int y) { }
		public void ScrollToRelative(int x, int y) { }
		public void Flick(Element element, int offsetX, int offsetY, int speed) { }
		public void Flick(int speedX, int speedY) { }
	}
}
