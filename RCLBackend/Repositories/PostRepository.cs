using Microsoft.EntityFrameworkCore;
using RCLBackend.Persistence.Context;
using RCLBackend.Persistence.Entities;
using RCLBackend.Repositories.Abstract;
using RCLBackend.Repositories.Core;

namespace RCLBackend.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly ShortStoryNetworkDbContext _context;

        public PostRepository(ShortStoryNetworkDbContext context) : base(context)
        {
            _context = context;
        }

        public bool PublishPost(Post post)
        {
            try
            {
                _context.Post.Add(post);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
