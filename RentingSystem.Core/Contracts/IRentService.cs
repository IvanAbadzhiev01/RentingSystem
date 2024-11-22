using RentingSystem.Core.Models.Admin;

namespace RentingSystem.Core.Contracts
{
    public interface IRentService
    {
        Task<IEnumerable<RentServiceModel>> AllAsync();

        Task RentAsync(int carId, string userId);

        Task ReturnAsync(int carId);

    }
}
