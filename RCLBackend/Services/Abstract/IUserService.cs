using RCLBackend.DTO;

namespace RCLBackend.Services
{
    public interface IUserService
    {
        void Register(UserRegisterDTO user);
        UserLoginDTO Login(UserLoginDTO user);
    }
}
