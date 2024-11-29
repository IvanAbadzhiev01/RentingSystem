using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RentingSystem.Core.Services;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;
using RentingSystem.Infrasturcture.Data;
using RentingSystem.Tests.TestInfrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentingSystem.Tests.Services
{
    [TestFixture]
    public class DealerServiceTests
    {
        private TestDbContext dbContext;
        private IRepository repository;
        private DealerService dealerService;

        [SetUp]
        public async Task SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "RentingSystemTestDb")
                .Options;

            dbContext = new TestDbContext(options);
            repository = new Repository(dbContext);
            dealerService = new DealerService(repository);

            await SeedDatabaseAsync();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task GetDealerIdAsync_ShouldReturnDealerId_WhenDealerExists()
        {
            var userId = "1";

            var result = await dealerService.GetDealerIdAsync(userId);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task GetDealerIdAsync_ShouldReturnNull_WhenDealerDoesNotExist()
        {
            var userId = "invalid-id";

            var result = await dealerService.GetDealerIdAsync(userId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task CreateAsync_ShouldAddDealerToDatabase()
        {
            var userId = "3";
            var phoneNumber = "987654321";

            await dealerService.CreateAsync(userId, phoneNumber);

            var dealer = await repository.All<Dealer>().FirstOrDefaultAsync(d => d.UserId == userId);

            Assert.That(dealer, Is.Not.Null);
            Assert.That(dealer.PhoneNumber, Is.EqualTo(phoneNumber));
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnTrue_WhenDealerExists()
        {
            var userId = "1";

            var result = await dealerService.ExistsByIdAsync(userId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnFalse_WhenDealerDoesNotExist()
        {
            var userId = "invalid-id";

            var result = await dealerService.ExistsByIdAsync(userId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task UserWithPhoneNumberExistsAsync_ShouldReturnTrue_WhenPhoneNumberExists()
        {
            var phoneNumber = "1234567890";

            var result = await dealerService.UserWithPhoneNumberExistsAsync(phoneNumber);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task UserWithPhoneNumberExistsAsync_ShouldReturnFalse_WhenPhoneNumberDoesNotExist()
        {
            var phoneNumber = "0000000000";

            var result = await dealerService.UserWithPhoneNumberExistsAsync(phoneNumber);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task UserHasRentsAsync_ShouldReturnTrue_WhenUserHasRents()
        {
            
            var userId = "user1";

            
            var result = await dealerService.UserHasRentsAsync(userId);

           
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task UserHasRentsAsync_ShouldReturnFalse_WhenUserHasNoRents()
        {
            
            var userId = "user3"; 

           
            var result = await dealerService.UserHasRentsAsync(userId);

            
            Assert.That(result, Is.False);
        }

        private async Task SeedDatabaseAsync()
        {
            var dealers = new List<Dealer>
            {
                new Dealer { Id = 1, UserId = "1", PhoneNumber = "1234567890" },
                new Dealer { Id = 2, UserId = "2", PhoneNumber = "0987654321" }
            };

            foreach (var dealer in dealers)
            {
                await repository.AddAsync(dealer);
            }

            await repository.SaveChangesAsync();

            var cars = new List<Car>
        {
            new Car { Id = 1, RenterId = "user1" },
            new Car { Id = 2, RenterId = "user2" },
            new Car { Id = 3, RenterId = null } 
        };

            foreach (var car in cars)
            {
                await repository.AddAsync(car);
            }

            await repository.SaveChangesAsync();
        }
    }
}
