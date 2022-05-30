using RCLBackend.Persistence.Entities;
using static RCLBackend.Repositories.Core.IRepository;

namespace RCLBackend.Repositories.Abstract
{
    public interface IUserRepository : IRepository<UserInfo>
    {
        void Register(UserInfo user);
        UserInfo GetUserByUserId(string userId);
        List<UserInfo> GetAllUsers();
    }
}
