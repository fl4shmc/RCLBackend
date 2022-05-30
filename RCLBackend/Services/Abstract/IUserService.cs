using RCLBackend.DTO;

namespace RCLBackend.Services
{
    public interface IUserService
    {
        void Register(UserRegisterDTO user);
        List<UserInfoDTO> GetAllUsers();
    }
}
