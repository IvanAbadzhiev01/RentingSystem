using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Enumerations;
using RentingSystem.Core.Models.Car;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;

namespace RentingSystem.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository repository;
        public AdminService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<CarQueryServiceModel> GetForReviewAsync(string? category = null, string? searchTerm = null, CarSorting sorting = CarSorting.Newest, int currentPage = 1, int carsPerPage = 1)
        {
            var carToShow = repository.AllReadOnly<Car>()
              .Where(c => c.IsApproved == false && c.IsDeleted == false);

            if (category != null)
            {
                carToShow = carToShow
                    .Where(c => c.Category.Name == category);
            };

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                carToShow = carToShow
                    .Where(c => (c.Title.ToLower().Contains(normalizedSearchTerm) ||
                                c.Description.ToLower().Contains(normalizedSearchTerm)));
            }

            carToShow = sorting switch
            {
                CarSorting.Price => carToShow
                    .OrderBy(c => c.PricePerDay),
                CarSorting.NotRentedFirst => carToShow
                    .OrderByDescending(c => c.RenterId == null)
                    .ThenByDescending(c => c.Id),
                _ => carToShow
                    .OrderByDescending(c => c.Id)

            };

            var car = await carToShow
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage)
                .Select(c => new CarServiceModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.RenterId != null
                })
                .ToListAsync();

            int totalCars = await carToShow.CountAsync();

            return new CarQueryServiceModel()
            {
                Cars = car,
                TotalCarCount = totalCars
            };
        }
    }
}
