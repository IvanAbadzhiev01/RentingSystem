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

        public async Task<IEnumerable<CarServiceModel>> AllCarsByDealerIdAsync(int dealerId)
        {
            return await repository.AllReadOnly<Car>()
                    .Where(c => c.DealerId == dealerId && c.IsApproved && c.IsDeleted == false)
                    .Select(c => new CarServiceModel()
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
        }

        public async Task<IEnumerable<CarServiceModel>> AllCarsByUserIdAsync(string userId)
        {
            return await repository.AllReadOnly<Car>()
                    .Where(c => c.RenterId == userId && c.IsApproved && c.IsDeleted == false)
                    .Select(c => new CarServiceModel()
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

        public async Task<CarDetailsServiceModel> CarDetailsByIdAsync(int id)
        {
            return await repository
                .AllReadOnly<Car>()
                .Where(c => c.IsApproved && c.IsDeleted == false)
                .Where(c => c.Id == id)
                .Select(c => new CarDetailsServiceModel()
                {
                    Id = c.Id,
                    Title = $"{c.Make} {c.Model}",
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Shift = c.Shift,
                    FuelType = c.FuelType,
                    Seat = c.Seat,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    Category = c.Category.Name,
                    Dealer = new DealerServiceModel()
                    {
                        FullName = $"{c.Dealer.User.FirstName} {c.Dealer.User.LastName}",
                        PhoneNumber = c.Dealer.PhoneNumber,
                        Email = c.Dealer.User.Email
                    },

                    IsRented = c.RenterId != null
                })
                .FirstAsync();
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

        public async Task DeleteAsync(int carId)
        {
            await repository.SoftDeleteAsync<Car>(carId);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int carId, CarFormModel model)
        {
            var car = await repository.GetByIdAsync<Car>(carId);

            if (car != null)
            {
                car.Title = $"{model.Make} {model.Model}";
                car.Make = model.Make;
                car.Model = model.Model;
                car.Year = model.Year;
                car.Shift = model.Shift;
                car.FuelType = model.FuelType;
                car.Seat = model.Seat;
                car.Description = model.Description;
                car.ImageUrl = model.ImageUrl;
                car.PricePerDay = model.PricePerDay;
                car.CategoryId = model.CategoryId;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository
                .AllReadOnly<Car>()
                .Where(c => c.IsApproved && c.IsDeleted == false)
                .AnyAsync(c => c.Id == id);
        }

        public async Task<CarFormModel> GetCarFormModelByIdAsync(int id)
        {
            var car = await repository
                 .AllReadOnly<Car>()
                 .Where(c => c.IsApproved && c.IsDeleted == false)
                 .Where(c => c.Id == id)
                 .Select(c => new CarFormModel()
                 {

                     Make = c.Make,
                     Model = c.Model,
                     Year = c.Year,
                     Shift = c.Shift,
                     FuelType = c.FuelType,
                     Seat = c.Seat,
                     Description = c.Description,
                     ImageUrl = c.ImageUrl,
                     PricePerDay = c.PricePerDay,
                     CategoryId = c.CategoryId,

                 })
                 .FirstOrDefaultAsync();

            if (car != null)
            {
                car.Categories = await AllCategoriesAsync();

            }
            return car;
        }

        public async Task<bool> HasDealerWithIdAsync(int carId, string currentUserId)
        {
            return await repository
                   .AllReadOnly<Car>()
                   .Where(c => c.IsApproved && c.IsDeleted == false)
                   .AnyAsync(c => c.Id == carId && c.Dealer.UserId == currentUserId);
        }

        public async Task<bool> IsRentedAsync(int carId)
        {
            bool result = false;

            var car = await repository.GetByIdAsync<Car>(carId);

            if (car != null)
            {
                result = car.RenterId != null;
            }

            return result;
        }


        public async Task<bool> IsRentedByUserWithIdAsync(int carId, string userId)
        {
            bool result = false;

            var car = await repository.GetByIdAsync<Car>(carId);

            if (car != null)
            {
                result = car.RenterId == userId;
            }

            return result;
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



        public async Task ApproveCarAsync(int carId)
        {
            var car = await repository.GetByIdAsync<Car>(carId);
            if (car != null && car.IsApproved == false)
            {
                car.IsApproved = true;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CarServiceModel>> GetUnApproveCarAsync()
        {
            return await repository
                .AllReadOnly<Car>()
                .Where(c => c.IsApproved == false && c.IsDeleted == false)
                .Select(c => new CarServiceModel()
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
        }
    }
}
