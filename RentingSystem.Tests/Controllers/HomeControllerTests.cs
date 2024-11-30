using Moq;
using NUnit.Framework;
using RentingSystem.Controllers;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace RentingSystem.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private Mock<ICarService> _mockCarService;
        private Mock<ILogger<HomeController>> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockCarService = new Mock<ICarService>();
            _mockLogger = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(_mockCarService.Object, _mockLogger.Object);
        }
        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public async Task Index_ReturnsViewWithCorrectModel()
        {
            
            var cars = new List<IndexViewModel>
            {
                new IndexViewModel { Id = 1, Title = "Car1", ImageUrl = "ImgUrl" },
                new IndexViewModel { Id = 2, Title = "Car2", ImageUrl = "ImgUrl" }
            };

            _mockCarService.Setup(service => service.LastForCarsAsync()).ReturnsAsync(cars);

            
            var result = await _controller.Index();
            

            var viewResult = result as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult.Model, Is.EqualTo(cars));
        }

        [Test]
        public async Task Error_ReturnsError404View_WhenStatusCodeIs404()
        {
            
            var result = _controller.Error(404);

            
            var viewResult = result as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult.ViewName, Is.EqualTo("Error404"));
        }


        [Test]
        public async Task Error_ReturnsError500View_WhenStatusCodeIs500()
        {
            
            var result = _controller.Error(500);

            
            var viewResult = result as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult.ViewName, Is.EqualTo("Error500"));
        }

        [Test]
        public async Task Error_ReturnsDefaultView_WhenStatusCodeIsOtherThan404Or500()
        {
           
            var result = _controller.Error(403);

            
            var viewResult = result as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult.ViewName, Is.Null);
        }
    }
}
