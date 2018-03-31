namespace Shaykhullin.Network.Core
{
	internal class ChannelConfig : IChannelConfig
	{
		public Injectable Injectable { get; } = new Injectable();

		public IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class =>
				Injectable.Register<TRegister>();
	}
}