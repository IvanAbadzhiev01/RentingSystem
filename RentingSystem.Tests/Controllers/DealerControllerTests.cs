using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RentingSystem.Controllers;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Dealer;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentingSystem.Tests.Controllers
{
    [TestFixture]
    public class DealerControllerTests
    {
        private Mock<IDealerService> mockDealerService;
        private DealerController dealerController;

        [SetUp]
        public void Setup()
        {
            mockDealerService = new Mock<IDealerService>();

            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "test-user-id")
            }));

            dealerController = new DealerController(mockDealerService.Object)
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
            dealerController.Dispose();
        }

        [Test]
        public async Task Get_Become_ShouldReturnBadRequest_IfUserIsAlreadyDealer()
        {
            mockDealerService.Setup(s => s.ExistsByIdAsync("test-user-id")).ReturnsAsync(true);

            var result = await dealerController.Become();

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task Get_Become_ShouldReturnViewWithModel_IfUserIsNotDealer()
        {
            mockDealerService.Setup(s => s.ExistsByIdAsync("test-user-id")).ReturnsAsync(false);

            var result = await dealerController.Become();

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.InstanceOf<BecomeDealerFormModel>());
        }

        [Test]
        public async Task Post_Become_ShouldReturnBadRequest_IfUserIsAlreadyDealer()
        {
            mockDealerService.Setup(s => s.ExistsByIdAsync("test-user-id")).ReturnsAsync(true);

            var model = new BecomeDealerFormModel { PhoneNumber = "123456789" };

            var result = await dealerController.Become(model);

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task Post_Become_ShouldAddModelError_IfPhoneNumberExists()
        {
            mockDealerService.Setup(s => s.ExistsByIdAsync("test-user-id")).ReturnsAsync(false);
            mockDealerService.Setup(s => s.UserWithPhoneNumberExistsAsync("123456789")).ReturnsAsync(true);
            var model = new BecomeDealerFormModel { PhoneNumber = "123456789" };

            var result = await dealerController.Become(model);

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(dealerController.ModelState["PhoneNumber"].Errors.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task Post_Become_ShouldAddModelError_IfUserHasRents()
        {
            mockDealerService.Setup(s => s.ExistsByIdAsync("test-user-id")).ReturnsAsync(false);
            mockDealerService.Setup(s => s.UserWithPhoneNumberExistsAsync("123456789")).ReturnsAsync(false);
            mockDealerService.Setup(s => s.UserHasRentsAsync("test-user-id")).ReturnsAsync(true);
            var model = new BecomeDealerFormModel { PhoneNumber = "123456789" };

            var result = await dealerController.Become(model);

            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(dealerController.ModelState["Error"].Errors.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task Post_Become_ShouldCreateDealer_AndRedirect_WhenModelIsValid()
        {
            mockDealerService.Setup(s => s.ExistsByIdAsync("test-user-id")).ReturnsAsync(false);
            mockDealerService.Setup(s => s.UserWithPhoneNumberExistsAsync("123456789")).ReturnsAsync(false);
            mockDealerService.Setup(s => s.UserHasRentsAsync("test-user-id")).ReturnsAsync(false);
            var model = new BecomeDealerFormModel { PhoneNumber = "123456789" };

            var result = await dealerController.Become(model);

            mockDealerService.Verify(s => s.CreateAsync("test-user-id", "123456789"), Times.Once);
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Car"));
        }
    }
}
