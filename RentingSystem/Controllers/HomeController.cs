using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Home;
using RentingSystem.Models;
using System.Diagnostics;

namespace RentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;
        private readonly ILogger<HomeController> _logger;
        public HomeController(
            ICarService _carService,
            ILogger<HomeController> logger)
        {
            carService = _carService;
            _logger = logger;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await carService.LastForCarsAsync();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
