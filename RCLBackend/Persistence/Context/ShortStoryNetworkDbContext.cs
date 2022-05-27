using Microsoft.EntityFrameworkCore;
using RCLBackend.Persistence.Entities;
using RCLBackend.Persistence.Entities.Mappings;

namespace RCLBackend.Persistence.Context
{
    public sealed class ShortStoryNetworkDbContext : DbContext
    {
        public ShortStoryNetworkDbContext(DbContextOptions<ShortStoryNetworkDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PostMap(modelBuilder.Entity<Post>());
            new StatVowelsMap(modelBuilder.Entity<StatVowels>());
            new UserInfoMap(modelBuilder.Entity<UserInfo>());
        }

        public DbSet<Post> Post { get; set; }
        public DbSet<StatVowels> StatVowels { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

    }
}
