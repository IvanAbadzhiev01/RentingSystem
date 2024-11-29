using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.CodeCoverage;
using RentingSystem.Core.Enumerations;
using RentingSystem.Core.Models.Car;
using RentingSystem.Core.Services;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;
using RentingSystem.Infrasturcture.Data;
using RentingSystem.Tests.TestInfrastructure;

namespace RentingSystem.Tests.Services
{
    [TestFixture]
    public class CarServiceTests
    {
        private TestDbContext dbContext;
        private IRepository repository;
        private CarService carService;


        [SetUp]
        public async Task SetUp()
        {
            var opt = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("RentingSystemTestDb")
                .Options;

            dbContext = new TestDbContext(opt);
            repository = new Repository(dbContext);
            carService = new CarService(repository);

            await SeedDatabaseAsync();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task AllAsync_ShouldReturnApprovedCarsOnly()
        {
            var result = await carService.AllAsync();

            Assert.That(1, Is.EqualTo(result.Cars.Count()));
            Assert.That("Toyota", Is.EqualTo(result.Cars.First().Make));
        }

        [Test]
        public async Task AllAsync_ShouldFilterByCategory()
        {
            var result = await carService.AllAsync(category: "SUV");

            Assert.That(1, Is.EqualTo(result.Cars.Count()));
            Assert.That("Toyota", Is.EqualTo(result.Cars.First().Make));
        }

        [Test]
        public async Task AllAsync_ShouldFilterBySearchTerm()
        {
            var result = await carService.AllAsync(searchTerm: "Reliable");

            Assert.That(1, Is.EqualTo(result.Cars.Count()));
            Assert.That("Toyota", Is.EqualTo(result.Cars.First().Make));
        }

        [Test]
        public async Task AllAsync_ShouldSortByPrice()
        {
            var result = await carService.AllAsync(sorting: CarSorting.Price);

            Assert.That(50, Is.EqualTo(result.Cars.First().PricePerDay));
        }

        [Test]
        public async Task CreateAsync_ShouldAddCarToDatabase()
        {
            var carForm = new CarFormModel
            {
                Make = "Honda",
                Model = "CR-V",
                Year = 2021,
                PricePerDay = 55,
                CategoryId = 1,
                Description = "Compact SUV",
                ImageUrl = "image3.jpg",
                Seat = 5,
                FuelType = "Petrol",
                Shift = "Automatic"
            };

            int carId = await carService.CreateAsync(carForm, 1);

            var car = await dbContext.Cars.FindAsync(carId);

            Assert.That(car, Is.Not.Null);
            Assert.That(car.Make, Is.EqualTo("Honda"));
            Assert.That(car.DealerId, Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteAsync_ShouldMarkCarAsDeleted()
        {
            await carService.DeleteAsync(1);

            var car = await dbContext.Cars.FindAsync(1);

            Assert.That(car.IsDeleted, Is.True);
        }

        [Test]
        public async Task AllCarsByDealerIdAsync_ShouldReturnDealerCars()
        {
            var result = await carService.AllCarsByDealerIdAsync(1);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Make, Is.EqualTo("Toyota"));
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrueForExistingCar()
        {
            var result = await carService.ExistsAsync(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalseForNonExistentCar()
        {
            var result = await carService.ExistsAsync(999);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CarDetailsByIdAsync_ShouldReturnCorrectCarDetails()
        {

            var car = await dbContext.Cars.FindAsync(1);


            var result = await carService.CarDetailsByIdAsync(1);


            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo("Toyota RAV4"));
            Assert.That(result.PricePerDay, Is.EqualTo(50));
            Assert.That(result.Dealer.FullName, Is.EqualTo("John Doe"));
            Assert.That(result.Dealer.PhoneNumber, Is.EqualTo("123456789"));
            Assert.That(result.Dealer.Email, Is.EqualTo("john.doe@example.com"));
            Assert.That(result.Category, Is.EqualTo("SUV"));
            Assert.That(result.IsRented, Is.True);
        }

        [Test]
        public async Task ApproveCarAsync_ShouldApproveCarSuccessfully()
        {
            await carService.ApproveCarAsync(2);
            var car = await dbContext.Cars.FindAsync(2);

            Assert.That(car.IsApproved, Is.True);
        }

        [Test]
        public async Task ApproveCarAsync_ShouldNotApproveAlreadyApprovedCar()
        {
            var car = await dbContext.Cars.FindAsync(1);
            var previousApprovalStatus = car.IsApproved;

            await carService.ApproveCarAsync(1);

            Assert.That(car.IsApproved, Is.EqualTo(previousApprovalStatus)); // Should stay the same
        }

        [Test]
        public async Task HasDealerWithIdAsync_ShouldReturnTrueForDealer()
        {
            var result = await carService.HasDealerWithIdAsync(1, "user123");

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task HasDealerWithIdAsync_ShouldReturnFalseForNonDealer()
        {
            var result = await carService.HasDealerWithIdAsync(1, "nonexistentuser");

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsRentedAsync_ShouldReturnTrueWhenCarIsRented()
        {
            var car = await dbContext.Cars.FindAsync(1);
            car.RenterId = "user123";
            await dbContext.SaveChangesAsync();

            var result = await carService.IsRentedAsync(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsRentedAsync_ShouldReturnFalseWhenCarIsNotRented()
        {
            var result = await carService.IsRentedAsync(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsRentedByUserWithIdAsync_ShouldReturnTrueWhenCarIsRentedByUser()
        {
            var car = await dbContext.Cars.FindAsync(1);
            car.RenterId = "user123";
            await dbContext.SaveChangesAsync();

            var result = await carService.IsRentedByUserWithIdAsync(1, "user123");

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsRentedByUserWithIdAsync_ShouldReturnFalseWhenCarIsRentedByDifferentUser()
        {
            var car = await dbContext.Cars.FindAsync(1);
            car.RenterId = "user123";
            await dbContext.SaveChangesAsync();

            var result = await carService.IsRentedByUserWithIdAsync(1, "user456");

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetAverageRatingAsync_ShouldReturnZeroWhenNoReviews()
        {
            var result = await carService.GetAverageRatingAsync(1);

            Assert.That(result, Is.EqualTo(0.00));
        }

        [Test]
        public async Task GetAverageRatingAsync_ShouldReturnAverageRatingWhenReviewsExist()
        {

            dbContext.Reviews.Add(new Review { UserId = "user123", CarId = 1, Rating = 4, Comment = "Test" });
            dbContext.Reviews.Add(new Review { UserId = "user123", CarId = 1, Rating = 5, Comment = "Test" });
            await dbContext.SaveChangesAsync();

            var result = await carService.GetAverageRatingAsync(1);

            Assert.That(result, Is.EqualTo(4.5));
        }

        [Test]
        public async Task AllCarsByUserIdAsync_ShouldReturnAllCarsByUserId()
        {
            var userId = "user1234";

            var result = await carService.AllCarsByUserIdAsync(userId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Make, Is.EqualTo("Toyota"));
        }


        [Test]
        public async Task AllCategoriesAsync_ShouldReturnAllCategories()
        {
            var result = await carService.AllCategoriesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Name, Is.EqualTo("SUV"));
        }

        [Test]
        public async Task AllCategoriesNamesAsync_ShouldReturnAllCategoryNames()
        {
            var result = await carService.AllCategoriesNamesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo("SUV"));
        }

        [Test]
        public async Task EditAsync_ShouldEditCarSuccessfully()
        {
            var carId = 1;

            var editModel = new CarFormModel
            {
                Make = "Honda",
                Model = "CR-V",
                Year = 2021,
                Shift = "Automatic",
                FuelType = "Diesel",
                Seat = 5,
                Description = "Updated description",
                ImageUrl = "updated_image.jpg",
                PricePerDay = 60,
                CategoryId = 1
            };

            await carService.EditAsync(carId, editModel);

            var editedCar = await repository.GetByIdAsync<Car>(carId);

            Assert.That(editedCar, Is.Not.Null);
            Assert.That(editedCar.Make, Is.EqualTo("Honda"));
            Assert.That(editedCar.Model, Is.EqualTo("CR-V"));
            Assert.That(editedCar.PricePerDay, Is.EqualTo(60));
            Assert.That(editedCar.Description, Is.EqualTo("Updated description"));
        }


        [Test]
        public async Task GetCarFormModelByIdAsync_ShouldReturnCorrectCarFormModel()
        {
           var carId = 1;

            var result = await carService.GetCarFormModelByIdAsync(carId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Make, Is.EqualTo("Toyota"));
            Assert.That(result.Model, Is.EqualTo("RAV4"));
            Assert.That(result.PricePerDay, Is.EqualTo(50));
        }

        [Test]
        public async Task LastForCarsAsync_ShouldReturnLastCars()
        {
            var result = await carService.LastForCarsAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1)); 
        }

        [Test]
        public async Task GetUnApproveCarAsync_ShouldReturnUnapprovedCars()
        {
            await SeedDatabaseAsync();

            var result = await carService.GetUnApproveCarAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Make, Is.EqualTo("Ford"));
        }

        private async Task SeedDatabaseAsync()
        {
            if (!await repository.AllReadOnly<Car>().AnyAsync())
            {
                var user = new ApplicationUser
                {
                    Id = "user123",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com"
                };
                var user2 = new ApplicationUser
                {
                    Id = "user1234",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com"
                };


                var dealer = new Dealer
                {
                    Id = 1,
                    UserId = user.Id,
                    User = user,
                    PhoneNumber = "123456789"
                };

                var category = new Category
                {
                    Id = 1,
                    Name = "SUV"
                };

                var car = new Car
                {
                    Id = 1,
                    Make = "Toyota",
                    Model = "RAV4",
                    Year = 2020,
                    Shift = "Automatic",
                    FuelType = "Gasoline",
                    Seat = 5,
                    Description = "Reliable SUV",
                    ImageUrl = "image1.jpg",
                    PricePerDay = 50,
                    CategoryId = category.Id,
                    DealerId = dealer.Id,
                    IsApproved = true,
                    IsDeleted = false,
                    RenterId = user2.Id
                };

                var car2 = new Car
                {
                    Id = 2,
                    Make = "Ford",
                    Model = "Explorer",
                    Year = 2019,
                    Shift = "Automatic",
                    FuelType = "Gasoline",
                    Seat = 5,
                    Description = "Spacious SUV",
                    ImageUrl = "image2.jpg",
                    PricePerDay = 70,
                    CategoryId = category.Id,
                    DealerId = dealer.Id,
                    IsApproved = false,
                    IsDeleted = false,
                    RenterId = null
                };

                await repository.AddAsync(user);
                await repository.AddAsync(user2);
                await repository.AddAsync(dealer);
                await repository.AddAsync(category);
                await repository.AddAsync(car);
                await repository.AddAsync(car2);

                await repository.SaveChangesAsync();
            }
        }



    }
}
