using RentingSystem.Core.Models.Car;

namespace RentingSystem.Core.Models.Admin
{
    public class MyCarsViewModel
    {
        public IEnumerable<CarServiceModel> AddedCars { get; set; } = new List<CarServiceModel>();
        public IEnumerable<CarServiceModel> RentedCars { get; set; } = new List<CarServiceModel>();
    }
}
