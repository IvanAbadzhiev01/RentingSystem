using RentingSystem.Core.Models.Home;

namespace RentingSystem.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<IndexViewModel>> LastForCarsAsync();

    }
}
