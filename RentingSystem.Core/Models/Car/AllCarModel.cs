using RentingSystem.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace RentingSystem.Core.Models.Car
{
    public class AllCarModel
    {
        public const int CarsPerPage = 3;

        public string Category { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public CarSorting Sorting { get; set; }

        public int TotalCarsCount { get; set; }

        public int CurrentPage { get; set; } = 1;

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<CarServiceModel> Cars { get; set; } = new List<CarServiceModel>();


    }
}
