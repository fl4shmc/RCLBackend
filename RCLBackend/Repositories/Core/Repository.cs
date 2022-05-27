using RCLBackend.Persistence.Context;
using static RCLBackend.Repositories.Core.IRepository;

namespace RCLBackend.Repositories.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ShortStoryNetworkDbContext _context;

        public Repository(ShortStoryNetworkDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
