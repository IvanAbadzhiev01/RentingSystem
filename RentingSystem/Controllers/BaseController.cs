using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RentingSystem.Infrastructure.Constants.RoleConstants;
namespace RentingSystem.Controllers
{
    [Authorize(Roles = AdminRole)]
    public class BaseController : Controller
    {
     
    }
}
