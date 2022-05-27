using RCLBackend.Repositories.Abstract;

namespace RCLBackend.Repositories.Core
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository User { get; }

		void Save();
		Task SaveAsync();
	}
}
