using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Car;
using System.Security.Claims;
using static RentingSystem.Infrastructure.Constants.ErrorConstants;
namespace RentingSystem.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService carService;
        private readonly IDealerService dealerService;
        public CarController(
            ICarService _carService,
            IDealerService _dealerService)
        {
            carService = _carService;
            dealerService = _dealerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllCarModel query)
        {
           var model = await carService.AllAsync(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarModel.CarsPerPage); 

            query.TotalCarsCount = model.TotalCarCount;
            query.Cars = model.Cars;
            query.Categories = await carService.AllCategoriesNamesAsync();
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> MyCar()
        {
            var userId = User.Id();
            IEnumerable<CarServiceModel> model;

            if (await dealerService.ExistsByIdAsync(userId))
            {
                int dealerId = await dealerService.GetDealerIdAsync(userId) ?? 0;
                model = await carService.AllCarsByDealerIdAsync(dealerId);
            }
            else
            {
                model = await carService.AllCarsByUserIdAsync(userId);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new CarDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if(!await dealerService.ExistsByIdAsync(User.Id()))
            {
                return RedirectToAction(nameof(DealerController.Become), "Dealer");
            }
            var model = new CarFormModel()
            {
                Categories = await carService.AllCategoriesAsync()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel entity)

        {
            if (!await dealerService.ExistsByIdAsync(User.Id()))
            {
               return RedirectToAction(nameof(DealerController.Become), "Dealer");
            }

            if (await carService.CategoryExistsAsync(entity.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(entity.CategoryId), CategoryNotExist);
            }
           
            if(ModelState.IsValid == false)
            {
                entity.Categories = await carService.AllCategoriesAsync();

                return View(entity);
            }

            int? dealerId = await dealerService.GetDealerIdAsync(User.Id());

            int newCarId = await carService.CreateAsync(entity, dealerId ?? 0);

            return RedirectToAction(nameof(Details), new { Id = newCarId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new CarFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new CarDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CarDetailsViewModel model)
        {
            return RedirectToAction(nameof(MyCar));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(MyCar));
        }

        [HttpPost]
        public async Task<IActionResult> Return(int id)
        {
            return RedirectToAction(nameof(MyCar));
        }
    }
}
