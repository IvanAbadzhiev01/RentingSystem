using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Dealer;
using System.Security.Claims;

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
            return RedirectToAction("All", "Car");
        }
    }
}
