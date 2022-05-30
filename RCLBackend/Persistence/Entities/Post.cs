namespace RCLBackend.Persistence.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string UserId { get; set; }
        public string? Date { get; set;  }
        public string? Poste { get; set; }
        public string? Title { get; set; }
        public string UserInfoUserId { get; set; }

        public UserInfo UserInfo { get; set; }
        public StatVowels StatVowels { get; set; }
    }
}
