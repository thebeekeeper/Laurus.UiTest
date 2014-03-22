using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Laurus.UiTest.Selenium.IntegrationTest
{
	public class RotationTests : IUseFixture<RemoteFixture>
	{
//		[Fact]
		public void Can_Change_Orientation()
		{
		}

		public void SetFixture(RemoteFixture data)
		{
			_fixture = data;
		}

		private RemoteFixture _fixture;
	}
}
