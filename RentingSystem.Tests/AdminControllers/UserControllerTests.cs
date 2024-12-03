using Microsoft.AspNetCore.Mvc;
using Moq;
using RentingSystem.Areas.Admin.Controllers;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Admin;

namespace RentingSystem.Tests.AdminControllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _controller;
        private Mock<IUserService> _userServiceMock;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _controller = new UserController(_userServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public async Task All_ShouldReturnViewWithUsers()
        {
            // Arrange
            var users = new List<UserServiceModel>
            {
                new UserServiceModel { Email = "user1@example.com", FullName = "user1" },
                new UserServiceModel { Email = "user2@example.com", FullName = "user2" }
            };

            _userServiceMock
                .Setup(us => us.AllAsync())
                .ReturnsAsync(users);

            // Act
            var result = await _controller.All();

            // Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.EqualTo(users));
        }

        [Test]
        public async Task All_ShouldCallUserServiceAllAsyncOnce()
        {
            // Act
            await _controller.All();

            // Assert
            _userServiceMock.Verify(us => us.AllAsync(), Times.Once);
        }
    }
}
