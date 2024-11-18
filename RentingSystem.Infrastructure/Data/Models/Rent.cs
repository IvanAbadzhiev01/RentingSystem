using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentingSystem.Infrastructure.Data.Models
{
    [Comment("Renting of the product")]
    public class Rent
    {
        [Key]
        [Comment("Rent identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User who rent the product")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!; 
        
        [Required]
        [Comment("Car which is rented")]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        
        [Required]
        [Comment("Date of renting")]
        public DateTime RentDate { get; set; }

        
        [Required]
        [Comment("Date of returning")]
        public DateTime ReturnDate { get; set; }
    }
}
