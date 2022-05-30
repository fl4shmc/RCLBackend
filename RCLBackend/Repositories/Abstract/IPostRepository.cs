using RCLBackend.Persistence.Entities;
using static RCLBackend.Repositories.Core.IRepository;

namespace RCLBackend.Repositories.Abstract
{
    public interface IPostRepository : IRepository<Post>
    {
        bool PublishPost(Post post);
    }
}
