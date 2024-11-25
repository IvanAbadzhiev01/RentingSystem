using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Car;
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
        public async Task AddReviewAsync(ReviewViewModel model, string userId)
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

        public async Task<CarReviewsViewModel> AllReviewByCarIdAsync(int carId)
        {
            var reviews = await repository.AllReadOnly<Review>()
                .Where(r => r.CarId == carId)
                .Select(r => new ReviewViewModel
                {
                    UserFullName = r.User.FirstName + " " + r.User.LastName,
                    CarId = r.CarId,
                    Rating = r.Rating,
                    Comment = r.Comment
                })
                .ToListAsync();

            var car = await repository.AllReadOnly<Car>()
                .Where(c => c.Id == carId && c.IsDeleted == false && c.IsApproved)
                .Select(c => new CarDetailsViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Year = c.Year,
                    ImageUrl = c.ImageUrl
                })
                .FirstOrDefaultAsync();

         


            var model = new CarReviewsViewModel
            {
                Car = car,
                Reviews = reviews
            };

            return model;
        }

        public async Task<bool> RentExistsAsync(int carId, string userId)
        {
            var rent = await repository.All<Rent>()
                .FirstOrDefaultAsync(r => r.UserId == userId && r.CarId == carId && r.ReturnDate <= DateTime.Now && r.IsReview == false);

            return rent != null;
        }
    }
}
