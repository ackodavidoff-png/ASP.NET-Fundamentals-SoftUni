using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        [RegularExpression(@"0\d{9}")]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
