namespace RentingSystem.Core.Models.Car
{
    public class CarQueryServiceModel
    {
        public int TotalCarCount { get; set; }
        public IEnumerable<CarServiceModel> Cars { get; set; } = new List<CarServiceModel>();
    }
}
