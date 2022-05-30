using RCLBackend.Repositories.Abstract;

namespace RCLBackend.Repositories.Core
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository User { get; }
		IWriterRepository Writer { get; }
		IPostRepository Post { get; }

		void Save();
		Task SaveAsync();
	}
}
