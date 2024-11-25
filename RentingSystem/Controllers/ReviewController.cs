using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Review;
using System.Security.Claims;

namespace RentingSystem.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService _reviewService)
        {
            reviewService = _reviewService;
        }

       
        [HttpGet]
        public IActionResult Create(int carId)
        {
            var model =  new ReviewViewModel()
            {
                CarId = carId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int carId, ReviewViewModel model)
        {
           

            if (ModelState.IsValid)
            {
                await reviewService.AddReviewAsync(model, User.Id());
                return RedirectToAction("All", "Car");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Reviews(int carId)
        {
            var model = await reviewService.AllReviewByCarIdAsync(carId);

            return View(model);
        }
    }
}
