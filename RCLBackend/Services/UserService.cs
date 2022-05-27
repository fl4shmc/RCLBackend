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
