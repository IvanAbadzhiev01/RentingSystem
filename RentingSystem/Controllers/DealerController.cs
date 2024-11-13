using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Dealer;
using System.Security.Claims;
using static RentingSystem.Infrastructure.Constants.ErrorConstants;
namespace RentingSystem.Controllers
{
    public class DealerController : BaseController
    {
        private readonly IDealerService dealerService;

        public DealerController(IDealerService _dealerService)
        {
            dealerService = _dealerService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await dealerService.ExistsByIdAsync(User.Id()))
            {
                return BadRequest();
            }
            var model = new BecomeDealerFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeDealerFormModel model)
        {
            if (await dealerService.ExistsByIdAsync(User.Id()))
            {
                return BadRequest();
            }
            if (await dealerService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneNumberExist);
            }
            if (await dealerService.UserHasRentsAsync(User.Id()))
            {
                ModelState.AddModelError("Error", HasRents);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await dealerService.CreateAsync(User.Id(), model.PhoneNumber);
            return RedirectToAction("All", "Car");
        }
    }

}