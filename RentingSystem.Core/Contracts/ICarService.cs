using RentingSystem.Core.Enumerations;
using RentingSystem.Core.Models.Car;
using RentingSystem.Core.Models.Home;

namespace RentingSystem.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<IndexViewModel>> LastForCarsAsync();

        Task<IEnumerable<CarCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(CarFormModel model, int dealerId);

        Task<CarQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            CarSorting sorting = CarSorting.Newest,
            int currentPage = 1,
            int carsPerPage = 1
        );

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        
    }
}
