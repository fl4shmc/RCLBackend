using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCLBackend.Persistence.Entities.Mappings
{
    public class FollowerMap
    {
        public FollowerMap(EntityTypeBuilder<Follower> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.UserId).IsRequired();
            entityBuilder.Property(x => x.WriterId).IsRequired();
        }

    }
}
