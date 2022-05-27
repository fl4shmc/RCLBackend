namespace RCLBackend.Persistence.Entities
{
    public class StatVowels
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public DateTime Date { get; set; }
        public int SingleVowelCount { get; set; }
        public int PairVowelCount { get; set; }
        public int TotalWordCount { get; set; }

        public Post Post { get; set; }
    }
}
