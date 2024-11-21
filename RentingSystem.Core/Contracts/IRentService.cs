using RentingSystem.Core.Models.Admin;

namespace RentingSystem.Core.Contracts
{
    public interface IRentService
    {
        Task<IEnumerable<RentServiceModel>> AllAsync();
       
        
    }
}
