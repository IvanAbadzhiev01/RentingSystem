using RentingSystem.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static RentingSystem.Infrastructure.Constants.DataConstants;
using static RentingSystem.Infrastructure.Constants.ErrorConstants;
namespace RentingSystem.Core.Models.Car
{
    public class CarServiceModel : ICarModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ReqiredFildError)]
        [StringLength(CarMakeMaxLength, MinimumLength = CarMakeMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = "Car Make")]
        public string Make { get; set; } = null!;

        [Required(ErrorMessage = ReqiredFildError)]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = "Car Model")]
        public string Model { get; set; } = null!;

        [Required(ErrorMessage = ReqiredFildError)]
        [Display(Name = "Car Year Of Production")]
        [Range(CarYearMinValue, CarYearMaxValue, ErrorMessage = RangeError)]
        public int Year { get; set; }



        [Required(ErrorMessage = ReqiredFildError)]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = ReqiredFildError)]
        [Range(typeof(decimal),
             CarPriceMinValue,
             CarPriceMaxValue,
             ErrorMessage = RangeError)]
        [Display(Name = "Car Price Per Day")]
        public decimal PricePerDay  { get; set; }

        [Display(Name = "Is Rented")]
        public bool IsRented  { get; set; }
    }
}