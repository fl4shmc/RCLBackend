namespace RCLBackend.Repositories.Core
{
    public interface IRepository
    {
        public interface IRepository<TEntity> where TEntity : class
        {
            IEnumerable<TEntity> GetAll();
        }
    }
}
