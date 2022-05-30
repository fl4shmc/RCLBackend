using RCLBackend.DTO;

namespace RCLBackend.Services.Abstract
{
    public interface IPostService
    {
        bool PublishPost(PostRequest request);
    }
}
