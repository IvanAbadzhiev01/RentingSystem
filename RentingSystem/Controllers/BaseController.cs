using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentingSystem.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
     
    }
}
