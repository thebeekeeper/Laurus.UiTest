using Laurus.UiTest.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.UiTest
{
	public class ControlRegistry : IControlRegistry
	{
		public ControlRegistry(object[] ctorParams)
		{
			_controlTypes = new Dictionary<Type, Type>();
			_ctorParams = ctorParams;
		}

		object IControlRegistry.GetControl(Type controlType, ILocator locator)
		{
			if (_controlTypes.ContainsKey(controlType))
			{
				if (typeof(ICollection<>).IsAssignableFrom(controlType))
				{
					Console.WriteLine("control collection requested");
				}
				else
				{
					var implType = _controlTypes[controlType];
					var inst = Activator.CreateInstance(implType, _ctorParams);
					((IBaseControl)inst).Find(locator);
					return inst;
				}
			}
			throw new Exception("Attempt to build non-existent control");
		}

		void IControlRegistry.RegisterControl<TControl, TImpl>()
		{
			_controlTypes.Add(typeof(TControl), typeof(TImpl));
		}

		private IDictionary<Type, Type> _controlTypes;
		private object[] _ctorParams;
	}
}
