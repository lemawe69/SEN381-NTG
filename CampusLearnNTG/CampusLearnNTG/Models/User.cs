using System.ComponentModel.DataAnnotations;

namespace CampusLearnNTG.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string Role { get; set; } // "Student" or "Tutor"

        public string StudentId { get; set; } // Optional
    }
}
