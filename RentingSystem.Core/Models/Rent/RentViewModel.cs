using System.ComponentModel.DataAnnotations;

namespace RentingSystem.Core.Models.Rent
{
    public class RentViewModel
    {
        public int CarId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public int Days { get; set; }
        public decimal TotalPrice => Days * PricePerDay;
    }
}
