

using RentingSystem.Infrastructure.Data.Models;

namespace RentingSystem.Core.Contracts
{
    public interface IBalanceService
    {
        Task<decimal> GetBalanceAsync(string userId);

        Task AddBalanceAsync(string userId, decimal amount);

        Task<bool> DeductBalanceAsync(string userId, decimal amount);

        Task<IEnumerable<Transaction>> GetUserTransactionsAsync(string userId);
    }
}
