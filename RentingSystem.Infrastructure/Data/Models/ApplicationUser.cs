using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static RentingSystem.Infrastructure.Constants.DataConstants;
namespace RentingSystem.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(ApplicationUserFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(ApplicationUserLastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), ApplicationUserBalanceMinValue, ApplicationUserBalanceMaxValue)]
        public decimal Balance { get; set; } = 0;


        public Dealer? Dealer { get; set; } 
    }
}
