using Microsoft.AspNetCore.Mvc;
using Moq;
using RentingSystem.Controllers;
using RentingSystem.Core.Contracts;

namespace RentingSystem.Tests.Controllers
{


    [TestFixture]
    public class ReviewApiControllerTests
    {
        private Mock<ICarService> _mockCarService;
        private ReviewApiController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockCarService = new Mock<ICarService>();
            _controller = new ReviewApiController(_mockCarService.Object);
        }

        [Test]
        public async Task GetAverageRating_ReturnsNotFound_WhenNoRatingExists()
        {
            var carId = 1;
            _mockCarService.Setup(service => service.GetAverageRatingAsync(carId)).ReturnsAsync(0);

            var result = await _controller.GetAverageRating(carId);

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }
    }

}
