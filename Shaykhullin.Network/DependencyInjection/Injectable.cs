using System.Collections.Generic;

namespace Shaykhullin.Network.Core
{
	public class Injectable : IInjectable
	{
		public IList<Dependency> Dependencies { get; } = new List<Dependency>();

		public IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class
		{
			var dependency = new Dependency(typeof(TRegister));
			Dependencies.Add(dependency);

			return new RegisterBuilder<TRegister>(dependency);
		}
	}
}
