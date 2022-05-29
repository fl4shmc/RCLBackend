namespace RCLBackend.Persistence.Entities
{
    public class Follower
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string WriterId { get; set; }

        //public ICollection<UserInfo> Users { get; set; }
    }
}
