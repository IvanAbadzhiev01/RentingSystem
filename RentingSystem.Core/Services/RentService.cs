using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Admin;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;

namespace RentingSystem.Core.Services
{
    public class RentService : IRentService
    {
        private readonly IRepository repository;

        public RentService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<RentServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<Car>()
                .Where(c => c.RenterId != null)
                .Where(c => c.IsDeleted == false)
                .Where(c => c.IsApproved)
                .Include(c => c.Dealer)
                .Include(c => c.Renter)
                .Select(c => new RentServiceModel()
                {
                    DealerEmail = c.Dealer.User.Email,
                    DealerFullName = $"{c.Dealer.User.FirstName} {c.Dealer.User.LastName}",
                    CarImageUrl = c.ImageUrl,
                    CarTitle = c.Title,
                    RenterEmail = c.Renter != null ? c.Renter.Email : string.Empty,
                    RenterFullName = c.Renter != null ? $"{c.Renter.FirstName} {c.Renter.LastName}" : string.Empty
                })
                .ToListAsync();

        }
    }
}
