using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RentingSystem.Areas.Admin.Controllers;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Admin;
using RentingSystem.Core.Models.Car;
using System.Security.Claims;

namespace RentingSystem.Tests.AdminControllers
{
    [TestFixture]
    public class CarControllerTests
    {
        private CarController _controller;
        private Mock<ICarService> _carServiceMock;
        private Mock<IDealerService> _dealerServiceMock;

        [SetUp]
        public void Setup()
        {
            _carServiceMock = new Mock<ICarService>();
            _dealerServiceMock = new Mock<IDealerService>();
            _controller = new CarController(_carServiceMock.Object, _dealerServiceMock.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "test-user-id")
            }));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public async Task MyCar_ShouldReturnViewWithMyCarsViewModel()
        {
            var dealerId = 1;
            var addedCars = new List<CarServiceModel>
            {
                new CarServiceModel { Id = 1, Model = "BMW X5" },
                new CarServiceModel { Id = 2, Model = "Audi A6" }
            };
            var rentedCars = new List<CarServiceModel>
            {
                new CarServiceModel { Id = 3, Model = "Tesla Model 3" }
            };

            _dealerServiceMock
                .Setup(ds => ds.GetDealerIdAsync(It.IsAny<string>()))
                .ReturnsAsync(dealerId);

            _carServiceMock
                .Setup(cs => cs.AllCarsByDealerIdAsync(dealerId))
                .ReturnsAsync(addedCars);

            _carServiceMock
                .Setup(cs => cs.AllCarsByUserIdAsync(It.IsAny<string>()))
                .ReturnsAsync(rentedCars);

            var result = await _controller.MyCar();

            Assert.That(result, Is.TypeOf<ViewResult>());
            var viewResult = result as ViewResult;
            var model = viewResult.Model as MyCarsViewModel;

            Assert.That(model.AddedCars, Is.EqualTo(addedCars));
            Assert.That(model.RentedCars, Is.EqualTo(rentedCars));
        }

        [Test]
        public async Task Approve_Get_ShouldReturnViewWithUnapprovedCars()
        {
            var unapprovedCars = new List<CarServiceModel>
            {
                new CarServiceModel { Id = 1, Model = "BMW X5" },
                new CarServiceModel { Id = 2, Model = "Audi A6" }
            };

            _carServiceMock
                .Setup(cs => cs.GetUnApproveCarAsync())
                .ReturnsAsync(unapprovedCars);

            var result = await _controller.Approve();

            Assert.That(result, Is.TypeOf<ViewResult>());
            var viewResult = result as ViewResult;

            Assert.That(viewResult.Model, Is.EqualTo(unapprovedCars));
        }

        [Test]
        public async Task Approve_Post_ShouldRedirectToApprove()
        {
            var carId = 1;

            _carServiceMock
                .Setup(cs => cs.ApproveCarAsync(carId))
                .Returns(Task.CompletedTask);

            var result = await _controller.Approve(carId);

            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;

            Assert.That(redirectResult.ActionName, Is.EqualTo(nameof(_controller.Approve)));
        }
    }
}
