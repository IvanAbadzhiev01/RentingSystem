using Microsoft.AspNetCore.Mvc;
using RentingSystem.Areas.Admin.Controllers;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Rent;
using RentingSystem.Core.Services;
using System.Security.Claims;
using static RentingSystem.Infrastructure.Constants.ToastrMessageConstants;


namespace RentingSystem.Controllers
{
    public class RentController : BaseController
    {
        private readonly ICarService carService;
        private readonly IDealerService dealerService;
        private readonly IRentService rentService;
        public RentController(
            ICarService _carService,
            IDealerService _dealerService,
            IRentService _rentService)
        {
            carService = _carService;
            dealerService = _dealerService;
            rentService = _rentService;
        }
        [HttpGet]
        public async Task<IActionResult> Rent(int id)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                TempData[Error] = CarRentError;
                return BadRequest();
            }
            if (await dealerService.ExistsByIdAsync(User.Id()) && User.IsAdmin() == false)
            {
                TempData[Error] = CarRentError;
                return Unauthorized();
            }
            if (await carService.IsRentedAsync(id))
            {
                TempData[Error] = CarRentError;
                return BadRequest();
            }

            var car = await rentService.GetCarForRentAsync(id);


            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmRent(int id, int days)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                TempData[Error] = CarRentError;
                return BadRequest();
            }
            if (await dealerService.ExistsByIdAsync(User.Id()) && User.IsAdmin() == false)
            {
                TempData[Error] = CarRentError;
                return Unauthorized();
            }
            if (await carService.IsRentedAsync(id))
            {
                TempData[Error] = CarRentError;
                return BadRequest();
            }


            await rentService.CreateRentAsync(id, days, User.Id());
            TempData[Success] = CarRentSuccess;
            return RedirectToAction("All", "Car");
        }



       
    }
}
