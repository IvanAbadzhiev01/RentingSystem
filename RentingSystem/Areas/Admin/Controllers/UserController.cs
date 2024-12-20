﻿using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;

namespace RentingSystem.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        public async Task<IActionResult> All()
        {
            var users = await userService.AllAsync();

            return View(users);
        }
        
    }
}
