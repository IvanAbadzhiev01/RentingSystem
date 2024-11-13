using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Home;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;

namespace RentingSystem.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repository;

        public CarService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<IndexViewModel>> LastForCarsAsync()
        {
           return await repository
                .AllReadOnly<Car>()
                .Where(c => c.IsApproved && c.IsDeleted == false)
                .OrderByDescending(c => c.Id)
                .Take(4)
                .Select(c => new IndexViewModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Title = c.Title

                })
                .ToListAsync();

        }
    }
}
