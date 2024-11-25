using RentingSystem.Core.Models.Car;

namespace RentingSystem.Core.Models.Review
{
    public class CarReviewsViewModel
    {
        public CarDetailsViewModel Car { get; set; } = null!;
        public List<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();
    }
}