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

        
    }
}
