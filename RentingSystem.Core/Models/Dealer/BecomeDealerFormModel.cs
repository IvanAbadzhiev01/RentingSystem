using System.ComponentModel.DataAnnotations;
using static RentingSystem.Infrastructure.Constants.ErrorConstants; 
using static RentingSystem.Infrastructure.Constants.DataConstants; 
namespace RentingSystem.Core.Models.Dealer
{
    public class BecomeDealerFormModel
    {
        [Required(ErrorMessage = ReqiredFildError)]
        [StringLength(DealerPhoneMaxLength,
            MinimumLength = DealerPhoneMinLength,
            ErrorMessage = StringLengthError)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
