using RCLBackend.Persistence.Context;
using RCLBackend.Persistence.Entities;
using RCLBackend.Repositories.Abstract;
using RCLBackend.Repositories.Core;
using System.Globalization;

namespace RCLBackend.Repositories
{
    public class WriterRepository : Repository<UserInfo>, IWriterRepository
    {
        private readonly ShortStoryNetworkDbContext _context;

        public WriterRepository(ShortStoryNetworkDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Post> GetWriterPosts(string userid)
        {
            try
            {
                return (from post in _context.Post where post.UserId.Equals(userid)
                        select new Post 
                        { 
                            PostId = post.PostId,
                            Title = post.Title,
                            Poste = post.Poste,
                            Date = post.Date,
                            UserId = userid
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserInfo> GetWriters(string userid, string searchQuery)
        {
            try
            {
                return (from follower in _context.Follower
                        join user in _context.UserInfo on follower.WriterId equals user.UserId
                        join post in _context.Post on user.UserId equals post.UserId
                        where follower.UserId.Equals(userid) && (searchQuery.Equals("null") || (follower.WriterId.StartsWith(searchQuery.Trim())))
                        select user).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
    }
}
