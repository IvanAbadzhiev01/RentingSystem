using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RentingSystem.Controllers;
using RentingSystem.Core.Contracts;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentingSystem.Tests.Controllers
{
    [TestFixture]
    public class ChatControllerTests
    {
        private Mock<IUserService> mockUserService;
        private ChatController chatController;

        [SetUp]
        public void Setup()
        {
            mockUserService = new Mock<IUserService>();

            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "test-user-id")
            }));

            chatController = new ChatController(mockUserService.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { User = userClaims }
                }
            };
        }

        [TearDown]
        public void TearDown()
        {
            chatController.Dispose();
        }

        [Test]
        public async Task Index_ShouldReturnViewWithUserName()
        {
            mockUserService.Setup(s => s.UserFullNameAsync("test-user-id")).ReturnsAsync("John Doe");

            var result = await chatController.Index();

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.EqualTo("John Doe"));
        }

        [Test]
        public async Task Index_ShouldReturnViewWithEmptyString_WhenUserFullNameIsNull()
        {
            mockUserService.Setup(s => s.UserFullNameAsync("test-user-id")).ReturnsAsync((string)null);

            var result = await chatController.Index();

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.EqualTo(null));
        }

        [Test]
        public async Task Index_ShouldReturnViewWithEmptyString_WhenUserFullNameIsEmpty()
        {
            mockUserService.Setup(s => s.UserFullNameAsync("test-user-id")).ReturnsAsync(string.Empty);

            var result = await chatController.Index();

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.EqualTo(string.Empty));
        }
    }
}
