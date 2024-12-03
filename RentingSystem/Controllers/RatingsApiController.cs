using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;

namespace RentingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewApiController : BaseController
    {
        private readonly ICarService _carService;

        public ReviewApiController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("average-rating/{carId}")]
        public async Task<IActionResult> GetAverageRating(int carId)
        {
            var averageRating = await _carService.GetAverageRatingAsync(carId);

            return Ok(new { averageRating = averageRating });
        }
    }
}
