using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;

namespace RentingSystem.Core.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IRepository repository;

        public BalanceService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddBalanceAsync(string userId, decimal amount)
        {
            var user = await repository
                .All<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                user.Balance += amount;

                await repository.SaveChangesAsync();
            }

        }

        public async Task<bool> DeductBalanceAsync(string userId, decimal amount)
        {
            var user = await repository
                .All<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id == userId);

            if(user == null)
            {
                return false;
            }

            if (user.Balance < amount)
            {
                return false;
            }

            user.Balance -= amount;
            await repository.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> GetBalanceAsync(string userId)
        {
            decimal balance = await repository.AllReadOnly<ApplicationUser>()
                 .Where(u => u.Id == userId)
                 .Select(u => u.Balance)
                 .FirstOrDefaultAsync();

            return balance;
        }
    }
}
