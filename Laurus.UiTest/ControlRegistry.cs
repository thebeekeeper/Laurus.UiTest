using Laurus.UiTest.Controls;
using System;
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

		T IControlRegistry.GetControl<T>(SelectorBase selector)
		{
			return (T)((IControlRegistry)this).GetControl(typeof(T), selector);
		}

		object IControlRegistry.GetControl(Type controlType, SelectorBase selector)
		{
			if (_controlTypes.ContainsKey(controlType))
			{
				var implType = _controlTypes[controlType];
				var inst = Activator.CreateInstance(implType, _ctorParams);
				((IBaseControl)inst).Find(selector);
				return inst;
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
