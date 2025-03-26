using System.ComponentModel.DataAnnotations;

namespace LoginSystem.Models
{
    public class User
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
