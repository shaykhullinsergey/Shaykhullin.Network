namespace Network.Core
{
	public interface IContainer
	{
		TResolve Resolve<TResolve>();
	}
}