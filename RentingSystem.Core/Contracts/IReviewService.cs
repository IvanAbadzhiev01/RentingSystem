using RentingSystem.Core.Models.Review;

namespace RentingSystem.Core.Contracts
{
    public interface IReviewService
    {
        Task AddReviewAsync(ReviewViewModel model, string userId);
        Task<CarReviewsViewModel> AllReviewByCarIdAsync(int carId);
    }
}
