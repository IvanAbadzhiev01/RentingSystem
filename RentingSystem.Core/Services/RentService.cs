using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Admin;
using RentingSystem.Core.Models.Rent;
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

        public async Task ReturnAsync(int carId)
        {
            var car = await repository.GetByIdAsync<Car>(carId);

            if (car != null)
            {
                car.RenterId = null;

                await repository.SaveChangesAsync();
            }
        }

        public async Task RentAsync(int carId, string userId)
        {
            var car = await repository.GetByIdAsync<Car>(carId);

            if (car != null)
            {
                car.RenterId = userId;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<RentViewModel> GetCarForRentAsync(int carId)
        {
            var car = await repository.GetByIdAsync<Car>(carId);


            var viewModel = new RentViewModel
            {
                CarId = car.Id,
                Title = car.Title,
                ImageUrl = car.ImageUrl,
                Description = car.Description,
                Year = car.Year,
                PricePerDay = car.PricePerDay
            };

            return viewModel;
        }

        public async Task CreateRentAsync(int carId, int days, string userId)
        {

            var car = await repository.GetByIdAsync<Car>(carId);
            if (car != null)
            {

                var rentStartDate = DateTime.Now;
                var rentEndDate = rentStartDate.AddDays(days);


                var rent = new Rent
                {
                    CarId = carId,
                    UserId = userId,
                    RentDate = rentStartDate,
                    ReturnDate = rentEndDate,

                };


                await repository.AddAsync<Rent>(rent);

                await RentAsync(carId, userId);

            }


        }

        public async Task<IEnumerable<RentHistoryViewModel>> GetRentHistoryAsync(string userId)
        {
            var rents = await repository
            .AllReadOnly<Rent>()
            .Where(r => r.UserId == userId)
            .Select(r => new RentHistoryViewModel
            {
                RentId = r.Id,
                CarTitle = r.Car.Title,
                ImageUrl = r.Car.ImageUrl,
                RentStartDate = r.RentDate,
                RentEndDate = r.ReturnDate,
                TotalPrice = (r.ReturnDate - r.RentDate).Days * r.Car.PricePerDay,
                CarId = r.CarId,
                IsReturned = r.IsReturned,
                IsReviewed = r.IsReview

            }).OrderByDescending(r => r.RentId)
            .ToListAsync();

            return rents;
        }
    }
}
