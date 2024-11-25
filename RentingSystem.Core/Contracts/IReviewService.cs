using RentingSystem.Core.Models.Review;

namespace RentingSystem.Core.Contracts
{
    public interface IReviewService
    {
        Task AddReview(ReviewViewModel model, string userId);
    }
}
