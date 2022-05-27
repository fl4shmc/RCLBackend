using RCLBackend.Persistence.Entities;
using static RCLBackend.Repositories.Core.IRepository;

namespace RCLBackend.Repositories.Abstract
{
    public interface IUserRepository : IRepository<UserInfo>
    {
        void Register(UserInfo user);
        void Login(UserInfo user);
        UserInfo GetUserByUserId(string userId);
    }
}
