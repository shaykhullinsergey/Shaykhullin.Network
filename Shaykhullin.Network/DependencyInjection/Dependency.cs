using System;

namespace Shaykhullin.Network.Core
{
	public class Dependency
	{
		public Type Register { get; }
		public Type Implemented { get; set; }
		public Type Lifecycle { get; set; }

		internal Dependency(Type register)
		{
			Register = register;
		}
	}
}
