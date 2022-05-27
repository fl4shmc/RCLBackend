using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCLBackend.Persistence.Entities.Mappings
{
    public class UserInfoMap
    {
        public UserInfoMap(EntityTypeBuilder<UserInfo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.UserId);

        }
    }
}
