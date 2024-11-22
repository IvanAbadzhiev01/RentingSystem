using Microsoft.AspNetCore.Mvc;
using RentingSystem.Areas.Admin.Controllers;
using RentingSystem.Core.Contracts;
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
        [HttpPost]
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

            await rentService.RentAsync(id, User.Id());
            TempData[Success] = CarRentSuccess;

            return RedirectToAction("All", "Car");
        }

        [HttpPost]
        public async Task<IActionResult> Return(int id)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                TempData[Error] = CarReturnError;
                return BadRequest();
            }

            if (await carService.IsRentedByUserWithIdAsync(id, User.Id()) == false)
            {
                TempData[Error] = CarReturnError;
                return Unauthorized();
            }
            TempData[Success] = CarReturnSuccess;
            await rentService.ReturnAsync(id);


            return RedirectToAction("All", "Car");

        }
    }
}
