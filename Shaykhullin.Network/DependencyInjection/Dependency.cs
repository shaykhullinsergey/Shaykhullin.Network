using System;

namespace Shaykhullin.Network.Core
{
	public class DependencyDto
	{
		public Type Register { get; }
		public Type Implemented { get; set; }
		public Type Lifecycle { get; set; }

		internal DependencyDto(Type register)
		{
			Register = register;
		}
	}
}
