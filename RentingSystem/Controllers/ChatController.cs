using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;
using System.Security.Claims;

namespace RentingSystem.Controllers
{
    public class ChatController : BaseController
    {
        private IUserService userService;
        public ChatController(IUserService _userService)
        {
            userService = _userService; 
        }
        public async Task<IActionResult> Index()
        {
            string userName = await userService.UserFullNameAsync(User.Id());

            return View("Index", userName);
        }
    }
}
