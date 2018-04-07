using System;
using System.Collections.Generic;

namespace Network.Core
{
	internal class Container : IContainer
	{
		private Dictionary<Type, DependencyDto> dependencies;
		public IConnection Connection { get; set; }

		public Container(Dictionary<Type, DependencyDto> dependencies)
		{
			this.dependencies = dependencies;
		}

		public object ResolveEvent(Type eventType, object data)
		{
			var ctor = eventType.GetConstructors()[0];
			var parameters = ctor.GetParameters();

			var arguments = new object[parameters.Length];

			for (var i = 0; i < arguments.Length; i++)
			{
				if(parameters[i].ParameterType == typeof(IConnection))
				{
					arguments[i] = Connection;
					continue;
				}

				var dataType = eventType.GetInterfaces()[0].GetGenericArguments()[0];
				if(parameters[i].ParameterType == dataType)
				{
					arguments[i] = data;
					continue;
				}

				var dto = dependencies[parameters[i].ParameterType];
				arguments[i] = dto.Factory != null
					? dto.Factory()
					: Resolve(dto.Implemented);
			}
			
			return Activator.CreateInstance(eventType, arguments);
		}

		public object Resolve(Type handler)
		{
			var ctor = handler.GetConstructors()[0];
			var parameters = ctor.GetParameters();
			
			var arguments = new object[parameters.Length];

			for (var i = 0; i < arguments.Length; i++)
			{
				var dto = dependencies[parameters[i].ParameterType];

				arguments[i] = dto.Factory != null
					? dto.Factory()
					: Resolve(dto.Implemented);
			}

			return Activator.CreateInstance(handler, arguments);
		}
	}
}
