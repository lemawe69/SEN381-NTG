using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearnNTG.Models
{
    public class PrivateMessage
    {
        [Key]
        public int Id { get; set; }

        public int SenderId { get; set; }

        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public int ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}

