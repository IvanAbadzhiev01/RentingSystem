using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Extensions;
using RentingSystem.Core.Models.Car;
using System.Security.Claims;
using static RentingSystem.Infrastructure.Constants.ErrorConstants;
using static RentingSystem.Infrastructure.Constants.ToastrMessageConstants;
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
        public async Task<IActionResult> All([FromQuery] AllCarModel query)
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
            if (User.IsAdmin())
            {
                return RedirectToAction("MyCar", "Car", new { area = "Admin" });
            }
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
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                return NotFound();
            }


            var model = await carService.CarDetailsByIdAsync(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!await dealerService.ExistsByIdAsync(User.Id()))
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

            if (ModelState.IsValid == false)
            {
                entity.Categories = await carService.AllCategoriesAsync();

                return View(entity);
            }

            int? dealerId = await dealerService.GetDealerIdAsync(User.Id());

            int newCarId = await carService.CreateAsync(entity, dealerId ?? 0);

            TempData[Success] = AddedCarSuccess;

            return RedirectToAction(nameof(MyCar));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await carService.HasDealerWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await carService.GetCarFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarFormModel entity)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await carService.HasDealerWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            if (await carService.CategoryExistsAsync(entity.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(entity.CategoryId), CategoryNotExist);

                return View(entity);
            }
            await carService.EditAsync(id, entity);

            TempData[Success] = EditCarSuccess;

            return RedirectToAction(nameof(Details), new { id, Information = entity.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            if (await carService.HasDealerWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var car = await carService.CarDetailsByIdAsync(id);

            var model = new CarDetailsViewModel()
            {
                Id = id,
                Title = car.Title,
                ImageUrl = car.ImageUrl,
                Year = car.Year
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CarDetailsViewModel model)
        {
            if (await carService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }
            if (await carService.HasDealerWithIdAsync(model.Id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await carService.DeleteAsync(model.Id);

            TempData[Success] = DeleteCarSuccess;


            return RedirectToAction(nameof(All));

        }


    }
}
