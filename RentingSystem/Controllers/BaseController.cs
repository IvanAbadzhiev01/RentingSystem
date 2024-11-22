using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RentingSystem.Infrastructure.Constants.AdministratorConstants;
namespace RentingSystem.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
     
    }
}
