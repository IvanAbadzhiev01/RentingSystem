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

        Task<IEnumerable<CarServiceModel>> AllCarsByDealerIdAsync(int dealerId);

        Task<IEnumerable<CarServiceModel>> AllCarsByUserIdAsync(string userId);

        Task<bool> ExistsAsync(int id);

        Task<CarDetailsServiceModel> CarDetailsByIdAsync(int id);

        Task EditAsync(int carId, CarFormModel model);

        Task<bool> HasDealerWithIdAsync(int carId, string currentUserId);

        Task<CarFormModel> GetCarFormModelByIdAsync(int id);

        Task DeleteAsync(int carId);

        Task<bool> IsRentedAsync(int carId);

        Task<bool> IsRentedByUserWithIdAsync(int carId, string userId);
        Task RentAsync(int carId, string userId);

        Task ReturnAsync(int carId);

        Task ApproveCarAsync(int carId);

        Task<IEnumerable<CarServiceModel>> GetUnApproveCarAsync();
    }
}
