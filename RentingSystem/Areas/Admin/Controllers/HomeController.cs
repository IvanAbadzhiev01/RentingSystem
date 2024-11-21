using Microsoft.AspNetCore.Mvc;

namespace RentingSystem.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
      public IActionResult Dashboard()
        {
            return View();
        }

    }
}
