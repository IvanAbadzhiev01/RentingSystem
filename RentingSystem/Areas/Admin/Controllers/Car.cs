using Microsoft.AspNetCore.Mvc;

namespace RentingSystem.Areas.Admin.Controllers
{
    public class Car : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
