using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RentingSystem.Core.Services;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;
using RentingSystem.Infrasturcture.Data;
using RentingSystem.Tests.TestInfrastructure;

namespace RentingSystem.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private TestDbContext dbContext;
        private IRepository repository;
        private UserService userService;

        [SetUp]
        public async Task SetUp()
        {
            var opt = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "RentingSystemTestDb")
                 .Options;

            dbContext = new TestDbContext(opt);
            repository = new Repository(dbContext);
            userService = new UserService(repository);

           await SeedDatabaseAsync();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task AllAsync_ShouldReturnAllUsers()
        {
            var result = await userService.AllAsync();

            Assert.That(2, Is.EqualTo(result.Count()));

            var firstUser = result.First();
            Assert.That("Ivan Ivanov", Is.EqualTo(firstUser.FullName));
            Assert.That("1234567890", Is.EqualTo(firstUser.PhoneNumber));
            Assert.That(firstUser.IsDealer, Is.True);

            var secondUser = result.Last();
            Assert.That("Petar Petrov", Is.EqualTo(secondUser.FullName));
            Assert.That(secondUser.PhoneNumber, Is.Null);
            Assert.That(secondUser.IsDealer, Is.False);
        }

        [Test]
        public async Task UserFullNameAsync_ShouldReturnCorrectFullName()
        {
            var fullName = await userService.UserFullNameAsync("1");

            Assert.That("Ivan Ivanov", Is.EqualTo(fullName));
        }

        [Test]
        public async Task UserFullNameAsync_ShouldReturnEmptyStringForInvalidUserId()
        {
            var fullName = await userService.UserFullNameAsync("invalid-id");

            Assert.That(string.Empty, Is.EqualTo(fullName));
        }
        private async Task SeedDatabaseAsync()
        {
            
            var users = new List<ApplicationUser>
    {
        new ApplicationUser
        {
            Id = "1",
            FirstName = "Ivan",
            LastName = "Ivanov",
            Email = "ivan@example.com",
            Dealer = new Dealer { PhoneNumber = "1234567890" }
        },
        new ApplicationUser
        {
            Id = "2",
            FirstName = "Petar",
            LastName = "Petrov",
            Email = "petar@example.com",
            Dealer = null
        }
    };

           
            foreach (var user in users)
            {
                await repository.AddAsync(user);
            }

            
            await repository.SaveChangesAsync();
        }

    }
}
