using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RCLBackend.Persistence.Entities.Mappings
{
    public class StatVowelsMap
    {
        public StatVowelsMap(EntityTypeBuilder<StatVowels> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
