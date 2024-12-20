﻿using Microsoft.AspNetCore.Mvc;

namespace RentingSystem.Components
{
    public class AdminMainMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
