namespace RentingSystem.Core.Contracts
{
    public interface IDealerService
    {
        Task<bool> IsDealerAsync(string userId);
    }
}
