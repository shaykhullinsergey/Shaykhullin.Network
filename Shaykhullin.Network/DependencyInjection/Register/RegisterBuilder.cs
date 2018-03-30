namespace Shaykhullin.Network.Core
{
	internal class RegisterBuilder<TRegister> : IRegisterBuilder<TRegister>
		where TRegister : class
	{
		public IImplementedByBuilder ImplementedBy<TImplemented>()
			where TImplemented : class, TRegister
		{
			return new ImplementedByBuilder();
		}

		public void As<TLifetime>() where TLifetime : ILifecycle
		{
			new ImplementedByBuilder()
				.As<TLifetime>();
		}
	}
}
