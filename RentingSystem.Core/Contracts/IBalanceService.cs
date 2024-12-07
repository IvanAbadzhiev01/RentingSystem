namespace RentingSystem.Core.Contracts
{
    public interface IBalanceService
    {
        Task<decimal> GetBalanceAsync(string userId);

        Task AddBalanceAsync(string userId, decimal amount);

        Task<bool> DeductBalanceAsync(string userId, decimal amount);
    }
}
