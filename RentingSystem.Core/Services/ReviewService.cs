using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Review;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;

namespace RentingSystem.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;

        public ReviewService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task AddReview(ReviewViewModel model, string userId)
        {
            var review = new Review
            {
                UserId = userId,
                CarId = model.CarId,
                Rating = model.Rating,
                Comment = model.Comment,

            };

            var rent = await repository.All<Rent>()
                .FirstOrDefaultAsync(r => r.UserId == userId && r.CarId == model.CarId && r.RentDate <= DateTime.Now && r.IsReview == false);

            rent.IsReview = true;

            await repository.AddAsync<Review>(review);
           
            await repository.SaveChangesAsync();
        }

     
    }
}
