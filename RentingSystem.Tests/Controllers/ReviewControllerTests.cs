using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RentingSystem.Controllers;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Car;
using RentingSystem.Core.Models.Review;
using System.Security.Claims;

namespace RentingSystem.Tests.Controllers
{
    [TestFixture]
    public class ReviewControllerTests
    {
        private Mock<IReviewService> _reviewServiceMock;
        private Mock<ICarService> _carServiceMock;
        private ReviewController _reviewController;

        [SetUp]
        public void Setup()
        {
            _reviewServiceMock = new Mock<IReviewService>();
            _carServiceMock = new Mock<ICarService>();
            _reviewController = new ReviewController(_reviewServiceMock.Object, _carServiceMock.Object);


            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "TestUserId")
            }));

            _reviewController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }

        [TearDown]
        public void TearDown()
        {
            _reviewController.Dispose();
        }

        [Test]
        public void Create_Get_ShouldReturnView_WithCorrectCarId()
        {

            int carId = 1;

            var result = _reviewController.Create(carId) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.TypeOf<ReviewViewModel>());
            var model = result.Model as ReviewViewModel;
            Assert.That(model.CarId, Is.EqualTo(carId));
        }

        [Test]
        public async Task Create_Post_ShouldReturnBadRequest_IfCarDoesNotExist()
        {

            int carId = 1;
            var model = new ReviewViewModel();
            _carServiceMock.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(false);

            var result = await _reviewController.Create(carId, model);

            Assert.That(result, Is.TypeOf<BadRequestResult>());
        }

        [Test]
        public async Task Create_Post_ShouldReturnBadRequest_IfRentDoesNotExist()
        {

            int carId = 1;
            var model = new ReviewViewModel();
            _carServiceMock.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _reviewServiceMock.Setup(s => s.RentExistsAsync(carId, "TestUserId")).ReturnsAsync(false);

            var result = await _reviewController.Create(carId, model);

            Assert.That(result, Is.TypeOf<BadRequestResult>());
        }

        [Test]
        public async Task Create_Post_ShouldRedirectToAllCars_WhenModelStateIsValid()
        {

            int carId = 1;
            var model = new ReviewViewModel { CarId = carId, Comment = "Test Review" };

            _carServiceMock.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _reviewServiceMock.Setup(s => s.RentExistsAsync(carId, "TestUserId")).ReturnsAsync(true);


            var result = await _reviewController.Create(carId, model) as RedirectToActionResult;


            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("All"));
            Assert.That(result.ControllerName, Is.EqualTo("Car"));
        }

        [Test]
        public async Task Create_Post_ShouldReturnView_WithModel_WhenModelStateIsInvalid()
        {
            int carId = 1;
            var model = new ReviewViewModel { CarId = carId };

            _carServiceMock.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _reviewServiceMock.Setup(s => s.RentExistsAsync(carId, "TestUserId")).ReturnsAsync(true);

            _reviewController.ModelState.AddModelError("Comment", "Comment is required");

            var result = await _reviewController.Create(carId, model) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.TypeOf<ReviewViewModel>());
        }

        [Test]
        public async Task Reviews_Get_ShouldReturnView_WithCorrectModel()
        {
            int carId = 1;
            var reviews = new List<ReviewViewModel>
                {
                    new ReviewViewModel { CarId = carId, Comment = "Great car!" },
                    new ReviewViewModel { CarId = carId, Comment = "Not bad." }
                };

            var carReviewsViewModel = new CarReviewsViewModel
            {
                Car = new CarDetailsViewModel { },
                Reviews = reviews
            };

            _reviewServiceMock
                .Setup(s => s.AllReviewByCarIdAsync(carId))
                .ReturnsAsync(carReviewsViewModel);

            var result = await _reviewController.Reviews(carId) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.TypeOf<CarReviewsViewModel>());
            var model = result.Model as CarReviewsViewModel;
            Assert.That(model.Reviews.Count, Is.EqualTo(2));
            Assert.That(model.Reviews[0].Comment, Is.EqualTo("Great car!"));
            Assert.That(model.Reviews[1].Comment, Is.EqualTo("Not bad."));
        }

    }
}
