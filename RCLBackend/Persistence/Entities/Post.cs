namespace RCLBackend.Persistence.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string UserId { get; set; }
        public string? Date { get; set;  }
        public string? Poste { get; set; }

        public UserInfo UserInfo { get; set; }
        public StatVowels StatVowels { get; set; }
    }
}
