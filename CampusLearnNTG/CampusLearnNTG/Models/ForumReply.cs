using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearnNTG.Models
{
    public class ForumReply
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public ForumPost Post { get; set; }

        public int? AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public User? Author { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
