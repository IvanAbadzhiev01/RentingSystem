using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Admin;
using RentingSystem.Core.Models.Rent;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;
using static RentingSystem.Infrastructure.Constants.AdministratorConstants;
namespace RentingSystem.Core.Services
{
    public class RentService : IRentService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        public RentService(
            IRepository _repository,
            UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            userManager = _userManager;
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
                PricePerDay = car.PricePerDay,
                DealerId = car.DealerId
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

        public async Task<bool> ProcessRentalPaymentAsync(string userId, int carDealerId, decimal rentalPrice)
        {
            var user = await repository
                .All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();


            var dealer = await repository
                .All<Dealer>()
                .Where(u => u.Id == carDealerId)
                .FirstOrDefaultAsync(); 
           

            var userDealer = await repository
                .All<ApplicationUser>()
                .Where(u => u.Id == dealer.UserId)
                .FirstOrDefaultAsync();


            var inRoleAdmin = await userManager.GetUsersInRoleAsync(AdminRole);

            var userAdmin = inRoleAdmin.FirstOrDefault();

            if (user == null || userDealer == null || userAdmin == null)
            {
                throw new InvalidOperationException("Invalid user data.");
            }

            

            if (user.Balance < rentalPrice)
            {
                return false; 
            }

            decimal ownerShare = rentalPrice * 0.90M;
            decimal adminShare = rentalPrice * 0.10M;

            
            user.Balance -= rentalPrice;
            userDealer.Balance += ownerShare;
            userAdmin.Balance += adminShare;

            await repository.SaveChangesAsync();

            
            await repository.AddAsync<Transaction>(new Transaction
            {
                UserId = user.Id,
                Amount = -rentalPrice,
                Description = "Car rental payment",
                Date = DateTime.Now
            });

            await repository.AddAsync(new Transaction
            {
                UserId = userDealer.Id,
                Amount = ownerShare,
                Description = "Car rental income",
                Date = DateTime.Now
            });

            await repository.AddAsync(new Transaction
            {
                UserId = userAdmin.Id,
                Amount = adminShare,
                Description = "Platform fee",
                Date = DateTime.Now
            });

            return true;
        }
    }
}
