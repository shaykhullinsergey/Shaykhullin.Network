using System;

namespace Network.Core
{
	public interface IContainerBuilder
	{
		IImplementedBuilder<TRegister> Register<TRegister>()
			where TRegister : class;
	}

	public interface IImplementedBuilder<TRegister>
		where TRegister : class
	{
		void ImplementedBy<TImplemented>(Func<TImplemented> factory = null)
			where TImplemented : TRegister;
	}
}
