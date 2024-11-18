using RentingSystem.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static RentingSystem.Infrastructure.Constants.DataConstants;
using static RentingSystem.Infrastructure.Constants.ErrorConstants;

namespace RentingSystem.Core.Models.Car
{
    public class CarFormModel : ICarModel
    {
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
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CarCategoryServiceModel> Categories { get; set; } =
            new List<CarCategoryServiceModel>();

        [Required(ErrorMessage = ReqiredFildError)]
        [Range(typeof(decimal),
            CarPriceMinValue,
            CarPriceMaxValue,
            ErrorMessage = RangeError)]
        [Display(Name = "Car Price Per Day")]
        public decimal PricePerDay { get; set; }

        [Required(ErrorMessage = ReqiredFildError)]
        [StringLength(CarDescriptionMaxLength, MinimumLength = CarDescriptionMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = "Car Description")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ReqiredFildError)]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; } = null!;


        [Required(ErrorMessage = ReqiredFildError)]
        [StringLength(CarShiftMaxLength, MinimumLength = CarShiftMinLength, ErrorMessage = StringLengthError)]
        [Display(Name = "Car Shift Type")]
        public string Shift { get; set; } = null!;

        [Required(ErrorMessage = ReqiredFildError)]
        [Range(CarSeatsMinValue, CarSeatsMaxValue, ErrorMessage = RangeError)]
        [Display(Name = "Car Seats Number")]
        public int Seat { get; set; }

        [Required(ErrorMessage = ReqiredFildError)]
        [StringLength(CarFuelTypeMaxLength, MinimumLength = CarFuelTypeMinLength, ErrorMessage = RangeError)]
        [Display(Name = "Car Fuel Type")]
        public string FuelType { get; set; } = null!;


    }
}
