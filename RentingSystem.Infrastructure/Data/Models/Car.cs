using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RentingSystem.Infrastructure.Constants.DataConstants;
namespace RentingSystem.Infrastructure.Data.Models
{
    [Comment("Car table")]
    public class Car
    {
        [Key]
        [Comment("Car identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Car Title")]
        [MaxLength(CarTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Comment("Car make")]
        [MaxLength(CarMakeMaxLength)]
        public string Make { get; set; } = string.Empty;

        [Required]
        [Comment("Car model")]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; } = string.Empty;

        [Required]
        [Comment("Car year of production")]
        public int Year { get; set; }

        [Required]
        [Comment("Car type")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Car price per day")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerDay { get; set; }

        [Required]
        [Comment("Car description")]
        [MaxLength(CarDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Car image url")]
        public string ImageUrl { get; set; } = string.Empty;


        [Required]
        [Comment("Car dealer")]
        public int DealerId { get; set; }

        [ForeignKey(nameof(DealerId))]
        public Dealer Dealer { get; set; } = null!;

        [Comment("User id of the renterer")]
        public string? RenterId
        {
            get; set;
        }
        [ForeignKey(nameof(RenterId))]
        public IdentityUser? Renter { get; set; }

        [Required]
        [MaxLength(CarShiftMaxLength)]
        [Comment("Car shift")]
        public string Shift { get; set; } = string.Empty;

        [Required]
        [Comment("Car seat")]
        public int Seat  { get; set; }

        [Required]
        [MaxLength(CarFuelTypeMaxLength)]
        [Comment("Car fuel type")]
        public string FuelType { get; set; } = string.Empty;

        [Comment("Is car deleted")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Is car approved by admin")]
        public bool IsApproved { get; set; } = false; 
    }
}
