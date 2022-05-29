using RCLBackend.DTO;
using RCLBackend.Repositories.Core;
using RCLBackend.Services.Abstract;

namespace RCLBackend.Services
{
    public class WriterService : IWriterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WriterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<PostDTO> GetWriterPosts(string userid)
        {
            List<PostDTO> posts = new List<PostDTO>();
            var list = _unitOfWork.Writer.GetWriterPosts(userid);

            foreach (var item in list) 
            { 
                PostDTO post = new PostDTO();
                post.PostId = item.PostId;
                post.Title = item.Title;
                post.UserId = item.UserId;
                post.Poste = item.Poste;
                post.Date = item.Date;
                posts.Add(post);
            }
            return posts;
        }

        List<UserInfoDTO> IWriterService.GetWriters(string userid, string searchQuery)
        {
            List<UserInfoDTO> writerList = new List<UserInfoDTO>();
            var list = _unitOfWork.Writer.GetWriters(userid, searchQuery);

            foreach (var item in list)
            {
                UserInfoDTO writer = new UserInfoDTO();
                writer.UserId = item.UserId;
                writer.FirstName = item.FirstName;
                writer.LastName = item.LastName;
                writer.EmailAddress = item.EmailAddress;
                writerList.Add(writer);
            }
            return writerList;
        }
    }
}
