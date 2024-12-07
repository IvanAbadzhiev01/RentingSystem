using RentingSystem.Core.Models.Admin;
using RentingSystem.Core.Models.Rent;

namespace RentingSystem.Core.Contracts
{
    public interface IRentService
    {
        Task<IEnumerable<RentServiceModel>> AllAsync();

        Task RentAsync(int carId, string userId);

        Task ReturnAsync(int carId);

        Task<RentViewModel> GetCarForRentAsync(int carId);

        Task CreateRentAsync(int carId, int days, string userId);

        Task<IEnumerable<RentHistoryViewModel>> GetRentHistoryAsync(string userId);

        Task<bool> ProcessRentalPaymentAsync(string userId, int carDealerId, decimal rentalPrice);

    }
}
