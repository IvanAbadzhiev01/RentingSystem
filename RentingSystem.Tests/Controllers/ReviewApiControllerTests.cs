using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RentingSystem.Controllers;
using RentingSystem.Core.Contracts;
using System.Threading.Tasks;

namespace RentingSystem.Tests.Controllers
{
    [TestFixture]
    public class ReviewApiControllerTests
    {
        private Mock<ICarService> _carServiceMock;
        private ReviewApiController _controller;

        [SetUp]
        public void Setup()
        {
            _carServiceMock = new Mock<ICarService>();
            _controller = new ReviewApiController(_carServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public async Task GetAverageRating_ShouldReturnOkWithAverageRating()
        {
            var carId = 1;
            var averageRating = 4.5;

            _carServiceMock
                .Setup(cs => cs.GetAverageRatingAsync(carId))
                .ReturnsAsync(averageRating);

            var result = await _controller.GetAverageRating(carId);

            Assert.That(result, Is.TypeOf<OkObjectResult>());

            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null, "OkObjectResult is null.");
            Assert.That(okResult.Value, Is.Not.Null, "The Value in OkObjectResult is null.");

            var data = okResult.Value;
            Assert.That(data.GetType().GetProperty("averageRating").GetValue(data, null), Is.EqualTo(averageRating));
        }


    }
}
