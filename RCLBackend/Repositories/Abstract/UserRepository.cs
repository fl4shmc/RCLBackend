using RCLBackend.Persistence.Context;
using RCLBackend.Persistence.Entities;
using RCLBackend.Repositories.Core;

namespace RCLBackend.Repositories.Abstract
{
    public class UserRepository : Repository<UserInfo>, IUserRepository
    {
        private readonly ShortStoryNetworkDbContext _context;

        public UserRepository(ShortStoryNetworkDbContext context) : base(context)
        {
            _context = context;
        }

        public List<UserInfo> GetAllUsers()
        {
            return _context.UserInfo.Where(x => x.UserRole != "M").ToList();
        }

        public UserInfo GetUserByUserId(string userId)
        {
            return _context.UserInfo.FirstOrDefault(x => x.UserId == userId);
        }

        public void Register(UserInfo user)
        {
            _context.UserInfo.Add(user);
            _context.SaveChanges();
        }

    }
}
