using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Models.Review;
using RentingSystem.Core.Services;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;
using RentingSystem.Infrasturcture.Data;
using RentingSystem.Tests.TestInfrastructure;

namespace RentingSystem.Tests.Services
{
    [TestFixture]
    public class ReviewServiceTests
    {
        private TestDbContext dbContext;
        private IRepository repository;
        private ReviewService reviewService;

        [SetUp]
        public async Task SetUp()
        {
            var opt = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "RentingSystemTestDb")
                 .Options;

            dbContext = new TestDbContext(opt);
            repository = new Repository(dbContext);
            reviewService = new ReviewService(repository);

            await SeedDatabaseAsync();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task AddReviewAsync_ShouldAddReviewAndMarkRentAsReviewed()
        {
            var reviewModel = new ReviewViewModel
            {
                CarId = 1,
                Rating = 5,
                Comment = "Great car!"
            };
            var userId = "1";

            await reviewService.AddReviewAsync(reviewModel, userId);

            var rent = await repository.All<Rent>()
                .FirstOrDefaultAsync(r => r.UserId == userId && r.CarId == reviewModel.CarId);

            var review = await repository.All<Review>()
                .FirstOrDefaultAsync(r => r.UserId == userId && r.CarId == reviewModel.CarId);

            Assert.That(rent.IsReview, Is.True);
            Assert.That(review, Is.Not.Null);
            Assert.That(review.Rating, Is.EqualTo(reviewModel.Rating));
            Assert.That(review.Comment, Is.EqualTo(reviewModel.Comment));
        }

        [Test]
        public async Task AllReviewByCarIdAsync_ShouldReturnReviewsForGivenCarId()
        {
            var carId = 1;

            var result = await reviewService.AllReviewByCarIdAsync(carId);

            Assert.That(result.Car, Is.Not.Null);
            Assert.That(result.Car.Id, Is.EqualTo(carId));
            Assert.That(result.Reviews.Count(), Is.EqualTo(1));

            var review = result.Reviews.First();
            Assert.That(review.UserFullName, Is.EqualTo("Ivan Ivanov"));
            Assert.That(review.Rating, Is.EqualTo(5));
            Assert.That(review.Comment, Is.EqualTo("Great car!"));
        }

        [Test]
        public async Task RentExistsAsync_ShouldReturnTrueIfRentExistsAndIsNotReviewed()
        {
            var carId = 1;
            var userId = "1";

            var result = await reviewService.RentExistsAsync(carId, userId);

            Assert.That(result, Is.True);
        }

        private async Task SeedDatabaseAsync()
        {
            var user = new ApplicationUser { Id = "1", FirstName = "Ivan", LastName = "Ivanov", Email = "ivan@example.com" };

            var car = new Car { Id = 1, Title = "Toyota Corolla", Year = 2020, IsApproved = true, IsDeleted = false };


            var rent =
                new Rent
                {
                    Id = 1,
                    CarId = 1,
                    UserId = "1",
                    RentDate = DateTime.Now.AddDays(-5),
                    ReturnDate = DateTime.Now.AddDays(-1),
                    IsReturned = true,
                    IsReview = false
                };
            var review = new Review
            {
                Id = 1,
                CarId = 1,
                UserId = "1",
                Rating = 5,
                Comment = "Great car!"
            };

            await repository.AddAsync(user);
            await repository.AddAsync(car);
            await repository.AddAsync(rent);
            await repository.AddAsync(review);
            await repository.SaveChangesAsync();
        }
    }
}
