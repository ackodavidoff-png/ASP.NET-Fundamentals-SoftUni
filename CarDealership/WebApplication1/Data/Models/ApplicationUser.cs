using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static WebApplication1.Common.EntityConstraints;

namespace WebApplication1.Data.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [MinLength(UserFirstNameMinLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [MinLength(UserFirstNameMinLength)]
        public string LastName { get; set; } = null!;
        [Required]
        [MaxLength(UsernameMaxLength)]
        [MinLength(UsernameMinLength)]
        public string Username { get; set; } = null!;
        [Required]
        [RegularExpression(PhoneNumberRegexPattern)]
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
        public bool IsAdmin { get; set; }
    }
}
