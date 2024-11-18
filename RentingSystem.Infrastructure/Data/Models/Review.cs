using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentingSystem.Infrastructure.Data.Models
{
    [Comment("Review of the rent")]
    public class Review
    {
        [Comment("Review identifier")]
        [Key]
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
        [Comment("Rating of the rent")]
        public int Rating { get; set; }

        [Comment("Comment of the rent")]
        public string? Comment { get; set; }
    }
}
