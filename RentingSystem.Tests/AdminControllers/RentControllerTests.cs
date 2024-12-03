using Microsoft.AspNetCore.Mvc;
using Moq;
using RentingSystem.Areas.Admin.Controllers;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Admin;

namespace RentingSystem.Tests.AdminControllers
{
    [TestFixture]
    public class RentControllerTests
    {
        private RentController _controller;
        private Mock<IRentService> _rentServiceMock;

        [SetUp]
        public void Setup()
        {
            _rentServiceMock = new Mock<IRentService>();
            _controller = new RentController(_rentServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public async Task All_ShouldReturnViewWithRents()
        {
            var rents = new List<RentServiceModel>
            {
                new RentServiceModel { DealerFullName = "John Doe", RenterEmail = "mail@" },
                new RentServiceModel { DealerFullName = "Jane Smith", RenterEmail = "mail@" }
            };

            _rentServiceMock
                .Setup(rs => rs.AllAsync())
                .ReturnsAsync(rents);

            var result = await _controller.All();

            Assert.That(result, Is.TypeOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.EqualTo(rents));
        }

        [Test]
        public async Task All_ShouldCallRentServiceAllAsyncOnce()
        {
            await _controller.All();

            _rentServiceMock.Verify(rs => rs.AllAsync(), Times.Once);
        }
    }
}
