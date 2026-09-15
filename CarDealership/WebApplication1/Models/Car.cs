using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Enums;

namespace WebApplication1.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        [Required]
        public int Year { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public FuelType FuelType { get; set; }
        [Required]
        public TransmissionType TransmissionType { get; set; }
        [Required]
        public int HorsePower { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public State State { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }
        public ApplicationUser Seller { get; set; }
    }
}
