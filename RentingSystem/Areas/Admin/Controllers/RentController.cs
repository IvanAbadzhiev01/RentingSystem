using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;

namespace RentingSystem.Areas.Admin.Controllers
{
    public class RentController : AdminBaseController
    {
        private readonly IRentService rentService;

        public RentController(IRentService _rentService)
        {
            rentService = _rentService;
        }

        public async Task<IActionResult> All()
        {
            var rents = await rentService.AllAsync();

            return View(rents);
        }


    }
}
