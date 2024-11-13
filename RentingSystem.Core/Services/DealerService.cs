using RentingSystem.Core.Contracts;
using RentingSystem.Infrastructure.Data.Common;

namespace RentingSystem.Core.Services
{
    public class DealerService : IDealerService
    {
        private readonly IRepository repository;

        public DealerService(IRepository _repository)
        {
                repository = _repository;
        }

        public Task<bool> IsDealerAsync(string userId)
        {
            
        }
    }
}
