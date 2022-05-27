using RCLBackend.Persistence.Context;
using RCLBackend.Repositories.Abstract;

namespace RCLBackend.Repositories.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShortStoryNetworkDbContext _context;

        public UnitOfWork(ShortStoryNetworkDbContext context)
        {
            _context = context;
            User = new UserRepository(_context);

        }

        public IUserRepository User { get; set; }

        public void Dispose()
        {
            try
            {
                _context.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
