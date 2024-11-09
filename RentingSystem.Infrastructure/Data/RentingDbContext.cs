using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentingSystem.Infrastructure.Data
{
    public class RentingDbContext : IdentityDbContext<IdentityUser>
    {
        public RentingDbContext(DbContextOptions<RentingDbContext> options)
            : base(options)
        {
        }
    }
}
