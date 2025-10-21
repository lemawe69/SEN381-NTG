namespace CampusLearnNTG.Models
{
    public class ForumPost
    {
        public int Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PostedAt { get; set; } = DateTime.Now;
        public int Replies { get; set; }
        public int Views { get; set; }
    }
}
