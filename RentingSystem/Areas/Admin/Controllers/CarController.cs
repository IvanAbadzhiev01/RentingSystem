using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Admin;
using RentingSystem.Core.Models.Car;
using System.Security.Claims;

namespace RentingSystem.Areas.Admin.Controllers
{
    public class CarController : AdminBaseController
    {
        private readonly ICarService carService;
        private readonly IDealerService dealerService;


        public CarController(
            ICarService _carService,
            IDealerService _dealerService
            )
        {
            carService = _carService;
            dealerService = _dealerService;
        }

        public async Task<IActionResult> MyCar()
        {
            var userId = User.Id();
            int dealerId = await dealerService.GetDealerIdAsync(userId) ?? 0;

            var myCars = new MyCarsViewModel()
            {
                AddedCars = await carService.AllCarsByDealerIdAsync(dealerId),
                RentedCars = await carService.AllCarsByUserIdAsync(userId)

            };

            return View(myCars);
        }

        [HttpGet]
        public async Task<IActionResult> Approve()
        {
            var model = await carService.GetUnApproveCarAsync();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Approve(int carId)
        {
            await carService.ApproveCarAsync(carId);

            return RedirectToAction(nameof(Approve));
        }
    }
}
