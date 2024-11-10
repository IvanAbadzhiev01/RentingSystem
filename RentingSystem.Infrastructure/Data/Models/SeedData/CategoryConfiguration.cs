using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentingSystem.Infrastructure.Data.Models.SeedData
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder.HasData(new Category[]
            {
                data.Jeep,
                data.Sedan,
                data.StationWagonan,
                data.Coupe,
                data.Convertible,
                data.Pickup,
                data.Hatchback
            });
        }
    }
}
