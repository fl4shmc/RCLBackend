using RCLBackend.DTO;
using RCLBackend.Persistence.Entities;
using RCLBackend.Repositories.Core;

namespace RCLBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<UserInfoDTO> GetAllUsers()
        {
            List<UserInfoDTO> users = new List<UserInfoDTO>();
            var result = _unitOfWork.User.GetAllUsers();
            foreach (var item in result)
            {
                UserInfoDTO user = new UserInfoDTO();
                user.UserId = item.UserId;
                user.FirstName = item.FirstName;
                user.LastName = item.LastName;
                user.EmailAddress = item.EmailAddress;
                user.IsEditor = item.IsEditor;
                user.IsBanned = item.IsBanned;
                user.UserRole = item.UserRole;
                users.Add(user);
            }
            return users;
        }

        public void Register(UserRegisterDTO user)
        {
            UserInfo usr = new UserInfo();
            usr.UserId = user.UserId;
            usr.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            usr.FirstName = user.FirstName;
            usr.LastName = user.LastName;
            usr.EmailAddress = user.EmailAddress;
            usr.UserRole = "U";
            usr.IsEditor = "FALSE";
            usr.IsBanned = "FALSE";

            _unitOfWork.User.Register(usr);
        }


    }
}
