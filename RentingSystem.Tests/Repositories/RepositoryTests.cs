using Microsoft.EntityFrameworkCore;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrasturcture.Data;
using RentingSystem.Tests.TestInfrastructure;

namespace RentingSystem.Tests.Repositories
{
    [TestFixture]
    public class RepositoryTests
    {
        private TestDbContext dbContext;
        private Repository repository;
        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "RentingSystemTestDb")
                .Options;

            dbContext = new TestDbContext(opt);
            repository = new Repository(dbContext);
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task AddAsync_SholdAddEntityToDatabase()
        {
            var entity = new TestEntity { Id = 1, Name = "Test" };

            await repository.AddAsync<TestEntity>(entity);
            await repository.SaveChangesAsync();

            Assert.That(1, Is.EqualTo(dbContext.Set<TestEntity>().Count()));
            Assert.That("Test", Is.EqualTo(dbContext.Set<TestEntity>().First().Name));
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnCorrectEntity()
        {
            var entity = new TestEntity { Id = 1, Name = "Test" };
            await repository.AddAsync<TestEntity>(entity);
            await repository.SaveChangesAsync();

            var result = await repository.GetByIdAsync<TestEntity>(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveEntityFromDatabase()
        {
            var entity = new TestEntity { Id = 1, Name = "Test" };
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            await repository.DeleteAsync<TestEntity>(1);
            await repository.SaveChangesAsync();

            Assert.That(0, Is.EqualTo(dbContext.Set<TestEntity>().Count()));   

        }

        [Test]
        public async Task SoftDeleteAsync_ShouldSetIsDeletedToTrue()
        {
            
            var entity = new TestEntity { Id = 1, Name = "Test", IsDeleted = false };
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            
            await repository.SoftDeleteAsync<TestEntity>(1);
            await repository.SaveChangesAsync();

            
            var updatedEntity = await dbContext.Set<TestEntity>().FindAsync(1);
            Assert.That(updatedEntity, Is.Not.Null);
            Assert.That(updatedEntity.IsDeleted, Is.True);
        }

        [Test]
        public void All_SholdReturnQueryble()
        {
            dbContext.Set<TestEntity>().Add(new TestEntity { Id = 1, Name = "Test 1" });
            dbContext.Set<TestEntity>().Add(new TestEntity { Id = 2, Name = "Test 2" });
            dbContext.SaveChanges();

            var result = repository.All<TestEntity>();

            Assert.That(2, Is.EqualTo(result.Count()));
        }

        [Test]
        public void AllReadOnly_ShouldReturnQueryableWithoutTracking()
        {
            
            dbContext.Set<TestEntity>().Add(new TestEntity { Id = 1, Name = "Test 1" });
            dbContext.Set<TestEntity>().Add(new TestEntity { Id = 2, Name = "Test 2" });
            dbContext.SaveChanges();

            
            var result = repository.AllReadOnly<TestEntity>();

            
            Assert.That(2, Is.EqualTo(result.Count()));
            Assert.That(result.AsNoTracking().Any(), Is.True);
        }
        public class TestEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
