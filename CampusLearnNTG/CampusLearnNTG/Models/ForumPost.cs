using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearnNTG.Models
{
    public class ForumPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int? AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public User? Author { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Upvotes { get; set; } = 0;
        public bool IsAnonymous { get; set; } = false;
    }
}

