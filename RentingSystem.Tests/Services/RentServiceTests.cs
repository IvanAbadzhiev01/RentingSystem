using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Services;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;
using RentingSystem.Infrasturcture.Data;
using RentingSystem.Tests.TestInfrastructure;

namespace RentingSystem.Tests.Services
{
    public class RentServiceTests
    {
        private TestDbContext dbContext;
        private IRepository repository;
        private RentService rentService;
        private UserManager<ApplicationUser> userManager;
        [SetUp]
        public async Task SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "RentingSystemTestDb")
                .Options;
            
            dbContext = new TestDbContext(options);
            repository = new Repository(dbContext);
            rentService = new RentService(repository, userManager);

            await SeedDatabaseAsync();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task AllAsync_ShouldReturnAllRentedCars_WhenCarsAreRented()
        {
            var result = (await rentService.AllAsync())
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result[0].RenterEmail, Is.EqualTo("user1@test.com"));
            Assert.That(result[0].DealerEmail, Is.Not.Empty);
            Assert.That(result[1].RenterEmail, Is.EqualTo("user2@test.com"));
        }


        [Test]
        public async Task AllAsync_ShouldReturnEmptyList_WhenNoCarsAreRented()
        {
            await repository.DeleteAsync<Car>(1);
            await repository.DeleteAsync<Car>(2);
            await repository.SaveChangesAsync();

            var result = await rentService.AllAsync();

            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task RentAsync_ShouldAssignRenterToCar_WhenCarExists()
        {
            var carId = 3;
            var userId = "user2";

            await rentService.RentAsync(carId, userId);

            var car = await repository.GetByIdAsync<Car>(carId);
            Assert.That(car.RenterId, Is.EqualTo(userId));
        }

        [Test]
        public async Task RentAsync_ShouldNotAssignRenterToCar_WhenCarDoesNotExist()
        {
            var carId = 999;
            var userId = "user3";

            await rentService.RentAsync(carId, userId);

            var car = await repository.GetByIdAsync<Car>(carId);
            Assert.That(car, Is.Null);
        }

        [Test]
        public async Task ReturnAsync_ShouldRemoveRenterFromCar_WhenCarIsRented()
        {
            var carId = 1;

            await rentService.ReturnAsync(carId);

            var car = await repository.GetByIdAsync<Car>(carId);
            Assert.That(car.RenterId, Is.Null);
        }

        [Test]
        public async Task ReturnAsync_ShouldDoNothing_WhenCarIsNotRented()
        {
            var carId = 3;

            await rentService.ReturnAsync(carId);

            var car = await repository.GetByIdAsync<Car>(carId);
            Assert.That(car.RenterId, Is.Null);
        }

        [Test]
        public async Task GetCarForRentAsync_ShouldReturnCarDetails_WhenCarExists()
        {
            var carId = 1;

            var result = await rentService.GetCarForRentAsync(carId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CarId, Is.EqualTo(carId));
            Assert.That(result.Title, Is.EqualTo("Toyota RAV4"));
        }

        [Test]
        public async Task CreateRentAsync_ShouldCreateRentRecord_WhenCarExists()
        {
            var carId = 3;
            var days = 5;
            var userId = "user2";

            await rentService.CreateRentAsync(carId, days, userId);

            var rent = await repository.All<Rent>()
                .FirstOrDefaultAsync(r => r.CarId == carId && r.UserId == userId);

            Assert.That(rent, Is.Not.Null);
            Assert.That(rent.RentDate, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(5)));
            Assert.That(rent.ReturnDate, Is.EqualTo(DateTime.Now.AddDays(days)).Within(TimeSpan.FromSeconds(5)));
        }

        [Test]
        public async Task CreateRentAsync_ShouldNotCreateRent_WhenCarDoesNotExist()
        {
            var carId = 999;
            var days = 3;
            var userId = "user1";

            await rentService.CreateRentAsync(carId, days, userId);

            var rent = await repository.All<Rent>()
                .FirstOrDefaultAsync(r => r.CarId == carId);

            Assert.That(rent, Is.Null);
        }

        [Test]
        public async Task GetRentHistoryAsync_ShouldReturnCorrectHistory()
        {
            var result = await rentService.GetRentHistoryAsync("user1");

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().CarTitle, Is.EqualTo("Toyota RAV4"));
            Assert.That(result.First().IsReturned, Is.True);
        }

        private async Task SeedDatabaseAsync()
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Id = "user1", UserName = "user1@test.com", Email = "user1@test.com" },
                new ApplicationUser { Id = "user2", UserName = "user2@test.com", Email = "user2@test.com" }
            };

            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "SUV" },
                new Category { Id = 2, Name = "Sedan" }
            };

            var dealers = new List<Dealer>
            {
                new Dealer { Id = 1, UserId = "user1", PhoneNumber = "123456789" },
                new Dealer { Id = 2, UserId = "user2", PhoneNumber = "987654321" }
            };

            var cars = new List<Car>
            {
                new Car { Id = 1, RenterId = "user1", Title = "Toyota RAV4", IsApproved = true, IsDeleted = false, PricePerDay = 100, CategoryId = 1, DealerId = 1 },
                new Car { Id = 2, RenterId = "user2", Title = "Honda Civic", IsApproved = true, IsDeleted = false, PricePerDay = 200, CategoryId = 2, DealerId = 2 },
                new Car { Id = 3, RenterId = null, Title = "BMW X5", IsApproved = true, IsDeleted = false, PricePerDay = 150, CategoryId = 1, DealerId = 1 }
            };
            var rents = new List<Rent>
            {
                new Rent { CarId = 1, UserId = "user1", RentDate = DateTime.Now.AddDays(-3), ReturnDate = DateTime.Now, IsReturned = true, IsReview = true },
                new Rent { CarId = 2, UserId = "user2", RentDate = DateTime.Now.AddDays(-5), ReturnDate = DateTime.Now.AddDays(-1), IsReturned = true, IsReview = false }
            };

            foreach (var user in users)
            {
                await repository.AddAsync(user);
            }

            foreach (var category in categories)
            {
                await repository.AddAsync(category);
            }

            foreach (var dealer in dealers)
            {
                await repository.AddAsync(dealer);
            }

            foreach (var car in cars)
            {
                await repository.AddAsync(car);
            }
            foreach (var rent in rents)
            {
                await repository.AddAsync(rent);
            }

            await repository.SaveChangesAsync();
        }

    }
}
