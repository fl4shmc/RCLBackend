using RCLBackend.DTO;
using RCLBackend.Persistence.Entities;
using RCLBackend.Repositories.Core;
using RCLBackend.Services.Abstract;

namespace RCLBackend.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool PublishPost(PostRequest request)
        {
            Post post = new Post();
            post.Title = request.Title;
            post.Poste = request.Poste;
            post.Date = DateTime.Now.ToShortDateString();
            post.UserId = request.UserId;
            post.UserInfoUserId = "test";
            var result = _unitOfWork.Post.PublishPost(post);
            _unitOfWork.Save();
            return result;
        }
    }
}
