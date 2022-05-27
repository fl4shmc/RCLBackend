using System.ComponentModel.DataAnnotations;

namespace RCLBackend.Persistence.Entities
{
    public class UserInfo
    {
        [MaxLength(12)]
        public string UserId { get; set; }
        public string? PasswordHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? UserRole { get; set; }
        public string? IsEditor { get; set; }
        public string? IsBanned { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}
