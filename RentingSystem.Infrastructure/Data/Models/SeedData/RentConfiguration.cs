using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentingSystem.Infrastructure.Data.Models.SeedData
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            var data = new SeedData();

            builder.HasData(new Rent[]
            {
                data.FirstRent,
                data.SecondRent,
                data.ThirdRent
            });
        }
    }
}
