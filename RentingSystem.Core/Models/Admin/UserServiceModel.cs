using System.ComponentModel.DataAnnotations;

namespace RentingSystem.Core.Models.Admin
{
    public class UserServiceModel
    {
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Name")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public bool IsDealer { get; set; }
    }
}
