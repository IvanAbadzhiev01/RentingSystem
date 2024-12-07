using System.ComponentModel.DataAnnotations;
using static RentingSystem.Infrastructure.Constants.DataConstants;
namespace RentingSystem.Infrastructure.Data.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(TransactionCommentMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }
    }
}
