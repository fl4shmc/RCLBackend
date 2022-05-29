using RCLBackend.Persistence.Entities;
using static RCLBackend.Repositories.Core.IRepository;

namespace RCLBackend.Repositories.Abstract
{
    public interface IWriterRepository : IRepository<UserInfo>
    {
        List<UserInfo> GetWriters(string userid, string searchQuery);
        List<Post> GetWriterPosts(string userid);
    }
}
