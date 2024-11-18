using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RentingSystem.Infrastructure.Constants.DataConstants;
namespace RentingSystem.Infrastructure.Data.Models
{
    [Comment("Dealer of the car")]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Dealer
    {
        [Key]
        [Comment("Dealer identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Dealer Phone Number")]
        [MaxLength(DealerPhoneMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Comment("Dealer User Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
