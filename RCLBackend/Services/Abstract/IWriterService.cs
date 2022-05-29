using RCLBackend.DTO;

namespace RCLBackend.Services.Abstract
{
    public interface IWriterService
    {
        List<UserInfoDTO> GetWriters(string userid, string searchQuery);
        List<PostDTO> GetWriterPosts(string userid);
    }
}
