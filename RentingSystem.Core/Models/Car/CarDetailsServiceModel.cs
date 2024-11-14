using System.ComponentModel.DataAnnotations;
using static RentingSystem.Infrastructure.Constants.DataConstants;
using static RentingSystem.Infrastructure.Constants.ErrorConstants;
namespace RentingSystem.Core.Models.Car
{
    public class CarDetailsServiceModel : CarServiceModel
    {
       
        public string Title { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Shift { get; set; } = null!;
        public int Seat { get; set; }
        public string FuelType { get; set; } = null!;

        public DealerServiceModel Dealer { get; set; } = null!;

    }
}
