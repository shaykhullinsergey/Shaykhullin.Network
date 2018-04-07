using System;
using System.Collections.Generic;

namespace Network.Core
{
	internal class ContainerBuilder : IContainerBuilder
	{
		private Dictionary<Type, DependencyDto> dependencies;

		public ContainerBuilder()
		{
			dependencies = new Dictionary<Type, DependencyDto>();
		}
		
		public IImplementedBuilder<TRegister> Register<TRegister>()
			where TRegister : class
		{
			var dto = new DependencyDto
			{
				Implemented = typeof(TRegister)
			};

			dependencies.Add(typeof(TRegister), dto);
			return new ImplementedBuilder<TRegister>(dto);
		}

		public IContainer Build()
		{
			return new Container(dependencies);
		}
	}

	public class DependencyDto
	{
		public Type Implemented { get; set; }
		public Func<object> Factory { get; set; }
	}
}
