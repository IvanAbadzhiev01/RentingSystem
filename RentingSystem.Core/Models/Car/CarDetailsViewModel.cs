namespace RentingSystem.Core.Models.Car
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

    }
}
