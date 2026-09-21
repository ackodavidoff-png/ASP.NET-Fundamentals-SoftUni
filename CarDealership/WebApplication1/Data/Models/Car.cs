using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebApplication1.Common.EntityConstraints;
using WebApplication1.Data.Models.Enums;

namespace WebApplication1.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(CarBrandNameMinLength)]
        [MaxLength(CarBrandNameMaxLength)]
        public string Brand { get; set; } = null!;
        [Required]
        [MinLength(CarModelNameMinLength)]
        [MaxLength(CarModelNameMaxLength)]
        public string Model { get; set; } = null!;
        [Required]
        public int Year { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public EngineType EngineType { get; set; }
        [Required]
        public TransmissionType TransmissionType { get; set; }
        [Required]
        public int HorsePower { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public State State { get; set; }
        [MinLength(CarDescriptionMinLength)]
        [MaxLength(CarDescriptionMaxLength)]
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }
        public virtual ApplicationUser Seller { get; set; }
    }
}
