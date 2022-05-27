namespace RCLBackend.DTO
{
    public class UserLoginDTO
    {
        public string UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? UserRole { get; set; }
        public string? IsEditor { get; set; }
        public string? IsBanned { get; set; }
    }
}
