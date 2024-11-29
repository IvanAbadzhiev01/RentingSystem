using Microsoft.EntityFrameworkCore;
using RentingSystem.Infrasturcture.Data;
using static RentingSystem.Tests.Repositories.RepositoryTests;

namespace RentingSystem.Tests.TestInfrastructure
{
    public class TestDbContext : ApplicationDbContext
    {
        public TestDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
