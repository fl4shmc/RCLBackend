using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCLBackend.Persistence.Entities.Mappings
{
    public class PostMap
    {
        public PostMap(EntityTypeBuilder<Post> entityBuilder)
        {
            entityBuilder.HasKey(x => x.PostId);

            entityBuilder.HasOne(a => a.UserInfo).WithMany(x => x.Posts).HasForeignKey(x => x.UserId);

        }
    }
}
