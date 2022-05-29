using RCLBackend.Repositories.Abstract;

namespace RCLBackend.Repositories.Core
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository User { get; }
		IWriterRepository Writer { get; }

		void Save();
		Task SaveAsync();
	}
}
