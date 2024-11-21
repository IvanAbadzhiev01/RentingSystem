using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RentingSystem.Infrastructure.Constants.AdministratorConstants;

namespace RentingSystem.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
