using Laurus.UiTest.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
				var implType = _controlTypes[controlType];
				var inst = Activator.CreateInstance(implType, _ctorParams);
				((IBaseControl)inst).Find(locator);
				return inst;
			}
			throw new Exception("Attempt to build non-existent control");
		}

		void IControlRegistry.RegisterControl<TControl, TImpl>()
		{
			_controlTypes.Add(typeof(TControl), typeof(TImpl));
		}

		void IControlRegistry.RegisterLocalControls()
		{
			var dirAssemblies = Directory.GetFiles(".", "Laurus.UiTest*.dll");
			foreach (var d in dirAssemblies)
			{
				var assembly = Assembly.LoadFrom(d);
				var types = assembly.GetTypes().Where(t => typeof(IBaseControl).IsAssignableFrom(t)).Where(t => t.IsInterface == false);
				foreach (var t in types)
				{
                    // this assumes the last interface is the one we're looking for, which seems to work so far
					var controlType = t.GetInterfaces().Last();
					var implType = t;
					_controlTypes.Add(controlType, implType);
				}
			}
		}

		private IDictionary<Type, Type> _controlTypes;
		private object[] _ctorParams;

	}
}
