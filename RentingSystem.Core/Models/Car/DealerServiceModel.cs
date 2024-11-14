using System.ComponentModel.DataAnnotations;

namespace RentingSystem.Core.Models.Car
{
    public class DealerServiceModel
    {
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}