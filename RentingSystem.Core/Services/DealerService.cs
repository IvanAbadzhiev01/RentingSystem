using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;

namespace RentingSystem.Core.Services
{
    public class DealerService : IDealerService
    {
        private readonly IRepository repository;

        public DealerService(IRepository _repository)
        {
                repository = _repository;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Dealer()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await repository.SaveChangesAsync();
        }

        public async Task<int?> GetDealerIdAsync(string userId)
        {
            return (await repository
                .AllReadOnly<Dealer>()
                .FirstOrDefaultAsync(d => d.UserId == userId))?.Id ?? null;
        }
        public async Task<bool> ExistsByIdAsync(string userId)
        {
           return await repository
                .AllReadOnly<Dealer>()
                .AnyAsync(d => d.UserId == userId);
        }

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            return await repository
                .AllReadOnly<Car>()
                .AnyAsync(c => c.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
           return await repository
                .AllReadOnly<Dealer>()
                .AnyAsync(d => d.PhoneNumber == phoneNumber);
        }
    }
}
