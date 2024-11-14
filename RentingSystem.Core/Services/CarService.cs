using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Enumerations;
using RentingSystem.Core.Models.Car;
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

        public async Task<CarQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, CarSorting sorting = CarSorting.Newest, int currentPage = 1, int carsPerPage = 1)
        {
            var carToShow = repository.AllReadOnly<Car>()
                .Where(c => c.IsApproved && c.IsDeleted == false);

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

        public async Task<IEnumerable<CarCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository
                .AllReadOnly<Category>()
                .Select(c => new CarCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository
                .AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository
                .AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(CarFormModel model, int dealerId)
        {
            Car car = new Car()
            {
                Title = $"{model.Make} {model.Model}",
                Make = model.Make,
                Model = model.Model,
                Year = model.Year,
                Shift = model.Shift,
                FuelType = model.FuelType,
                Seat = model.Seat,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerDay = model.PricePerDay,
                CategoryId = model.CategoryId,
                DealerId = dealerId
            };

            await repository.AddAsync(car);
            await repository.SaveChangesAsync();

            return car.Id;
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
