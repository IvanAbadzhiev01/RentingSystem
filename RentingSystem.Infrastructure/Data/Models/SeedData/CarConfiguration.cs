using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentingSystem.Infrastructure.Data.Models.SeedData
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            var data = new SeedData();

            builder.HasData(new Car[]
            {
                data.FirstCar,
                data.SecondCar,
                data.ThirdCar
            });
        }
    }
}
