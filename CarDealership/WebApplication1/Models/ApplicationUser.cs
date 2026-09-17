using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        [RegularExpression(@"0\d{9}")]
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
        public bool IsAdmin { get; set; }
    }
}
