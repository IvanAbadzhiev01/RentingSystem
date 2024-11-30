using Moq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RentingSystem.Controllers;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Rent;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using RentingSystem.Infrasturcture.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace RentingSystem.Tests.Controllers
{
    [TestFixture]
    public class RentControllerTests
    {
        private Mock<ICarService> carServiceMock;
        private Mock<IDealerService> dealerServiceMock;
        private Mock<IRentService> rentServiceMock;
        private RentController rentController;

        [SetUp]
        public void SetUp()
        {
            carServiceMock = new Mock<ICarService>();
            dealerServiceMock = new Mock<IDealerService>();
            rentServiceMock = new Mock<IRentService>();

            rentController = new RentController(carServiceMock.Object, dealerServiceMock.Object, rentServiceMock.Object);

            
            var tempDataMock = new Mock<ITempDataDictionary>();
            rentController.TempData = tempDataMock.Object;

            
            var userMock = new Mock<ClaimsPrincipal>();
            userMock.Setup(u => u.FindFirst(ClaimTypes.NameIdentifier))
                    .Returns(new Claim(ClaimTypes.NameIdentifier, "user-id"));
            userMock.Setup(u => u.IsInRole("Admin")).Returns(false);

            rentController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userMock.Object }
            };
        }

        [TearDown]
        public void TearDown()
        {
            rentController.Dispose();
        }

        [Test]
        public async Task Rent_DependenciesCheck_ShouldNotThrowNullReferenceException()
        {
            
            int carId = 1;

            
            carServiceMock.Setup(cs => cs.ExistsAsync(carId))
                          .ReturnsAsync(true);

            
            dealerServiceMock.Setup(ds => ds.ExistsByIdAsync(It.IsAny<string>()))
                             .ReturnsAsync(false);

          
            rentServiceMock.Setup(rs => rs.GetCarForRentAsync(carId))
                           .ReturnsAsync(new RentViewModel
                           {
                               CarId = carId,
                               Title = "Test Car",
                               ImageUrl = "https://example.com/car.jpg",
                               Description = "A test car for renting",
                               Year = 2022,
                               PricePerDay = 50,
                               Days = 5
                           });

            
            Assert.That(carServiceMock, Is.Not.Null, "carServiceMock е null");
            Assert.That(dealerServiceMock, Is.Not.Null, "dealerServiceMock е null");
            Assert.That(rentServiceMock, Is.Not.Null, "rentServiceMock е null");
            Assert.That(rentController.TempData, Is.Not.Null, "TempData не е конфигуриран");
            Assert.That(rentController.ControllerContext.HttpContext.User, Is.Not.Null, "User не е конфигуриран в ControllerContext");

            
            Assert.DoesNotThrowAsync(async () => await carServiceMock.Object.ExistsAsync(carId), "carService.ExistsAsync хвърля грешка");
            Assert.DoesNotThrowAsync(async () => await dealerServiceMock.Object.ExistsByIdAsync("user-id"), "dealerService.ExistsByIdAsync хвърля грешка");

            try
            {
                
                var result = await rentController.Rent(carId);
                Assert.That(result, Is.Not.Null, "Методът Rent връща null");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Тестът хвърли грешка: {ex.Message}");
            }
        }

        [Test]
        public async Task Rent_ShouldReturnBadRequest_WhenCarDoesNotExist()
        {
            
            int carId = 1;
            carServiceMock.Setup(cs => cs.ExistsAsync(carId))
                          .ReturnsAsync(false);

           
            var result = await rentController.Rent(carId);

            
            Assert.That(result, Is.TypeOf<BadRequestResult>());
        }

        [Test]
        public async Task Rent_ShouldReturnUnauthorized_WhenDealerIsNotAdmin()
        {
            
            int carId = 1;
            carServiceMock.Setup(cs => cs.ExistsAsync(carId))
                          .ReturnsAsync(true);
            dealerServiceMock.Setup(ds => ds.ExistsByIdAsync(It.IsAny<string>()))
                             .ReturnsAsync(true);

          
            var result = await rentController.Rent(carId);

            
            Assert.That(result, Is.TypeOf<UnauthorizedResult>());
        }

        [Test]
        public async Task Rent_ShouldReturnView_WhenCarIsAvailable()
        {
            
            int carId = 1;
            carServiceMock.Setup(cs => cs.ExistsAsync(carId))
                          .ReturnsAsync(true);
            carServiceMock.Setup(cs => cs.IsRentedAsync(carId))
                          .ReturnsAsync(false);
            rentServiceMock.Setup(rs => rs.GetCarForRentAsync(carId))
                           .ReturnsAsync(new RentViewModel
                           {
                               CarId = carId,
                               Title = "Test Car",
                               PricePerDay = 50
                           });

            
            var result = await rentController.Rent(carId);

            
            Assert.That(result, Is.TypeOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.InstanceOf<RentViewModel>());
        }

        [Test]
        public async Task History_ShouldRedirect_WhenUserIsDealerButNotAdmin()
        {
            
            dealerServiceMock.Setup(ds => ds.ExistsByIdAsync(It.IsAny<string>())).ReturnsAsync(true); 
           
            var result = await rentController.History();

            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Car"));
        }

        [Test]
        public async Task History_ShouldReturnEmptyList_WhenNoRentHistory()
        {
            
            var rents = new List<RentHistoryViewModel>();
            rentServiceMock.Setup(rs => rs.GetRentHistoryAsync(It.IsAny<string>())).ReturnsAsync(rents);
            dealerServiceMock.Setup(ds => ds.ExistsByIdAsync(It.IsAny<string>())).ReturnsAsync(false);

            
            var result = await rentController.History();

            
            Assert.That(result, Is.TypeOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.EqualTo(rents));
        }

        [Test]
        public async Task Rent_ShouldReturnUnauthorized_WhenUserIsDealerButNotAdmin()
        {
            
            dealerServiceMock.Setup(ds => ds.ExistsByIdAsync(It.IsAny<string>())).ReturnsAsync(true); 
            
            carServiceMock.Setup(cs => cs.ExistsAsync(It.IsAny<int>())).ReturnsAsync(true); 

            
            var result = await rentController.Rent(1); 

            
            Assert.That(result, Is.TypeOf<UnauthorizedResult>());
        }

        [Test]
        public async Task Rent_ShouldReturnBadRequest_WhenCarIsAlreadyRented()
        {
            
            carServiceMock.Setup(cs => cs.ExistsAsync(It.IsAny<int>())).ReturnsAsync(true); 
            carServiceMock.Setup(cs => cs.IsRentedAsync(It.IsAny<int>())).ReturnsAsync(true); 

           
            var result = await rentController.Rent(1); 

            
            Assert.That(result, Is.TypeOf<BadRequestResult>());
        }

        [Test]
        public async Task Rent_ShouldReturnView_WhenCarIsValidAndAvailable()
        {
            
            var rentViewModel = new RentViewModel
            {
                CarId = 1,
                Title = "Car 1",
                PricePerDay = 50,
                Days = 5
            };

            carServiceMock.Setup(cs => cs.ExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
            carServiceMock.Setup(cs => cs.IsRentedAsync(It.IsAny<int>())).ReturnsAsync(false); 
            rentServiceMock.Setup(rs => rs.GetCarForRentAsync(It.IsAny<int>())).ReturnsAsync(rentViewModel); 

          
            var result = await rentController.Rent(1); 

            Assert.That(result, Is.TypeOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.EqualTo(rentViewModel));
        }

        [Test]
        public async Task ConfirmRent_ShouldReturnBadRequest_WhenCarDoesNotExist()
        {
           
            carServiceMock.Setup(cs => cs.ExistsAsync(It.IsAny<int>())).ReturnsAsync(false); 

            
            var result = await rentController.ConfirmRent(1, 5); 

           
            Assert.That(result, Is.TypeOf<BadRequestResult>());
        }

        [Test]
        public async Task ConfirmRent_ShouldReturnUnauthorized_WhenUserIsDealerButNotAdmin()
        {
            
            dealerServiceMock.Setup(ds => ds.ExistsByIdAsync(It.IsAny<string>())).ReturnsAsync(true); 
            carServiceMock.Setup(cs => cs.ExistsAsync(It.IsAny<int>())).ReturnsAsync(true); 

            
            var result = await rentController.ConfirmRent(1, 5); 

            
            Assert.That(result, Is.TypeOf<UnauthorizedResult>());
        }

        [Test]
        public async Task ConfirmRent_ShouldReturnBadRequest_WhenCarIsAlreadyRented()
        {
            
            carServiceMock.Setup(cs => cs.ExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
            carServiceMock.Setup(cs => cs.IsRentedAsync(It.IsAny<int>())).ReturnsAsync(true); 

            var result = await rentController.ConfirmRent(1, 5); 

            
            Assert.That(result, Is.TypeOf<BadRequestResult>());
        }

        [Test]
        public async Task ConfirmRent_ShouldRedirect_WhenCarIsRentedSuccessfully()
        {
            
            carServiceMock.Setup(cs => cs.ExistsAsync(It.IsAny<int>())).ReturnsAsync(true); 
            carServiceMock.Setup(cs => cs.IsRentedAsync(It.IsAny<int>())).ReturnsAsync(false);
            rentServiceMock.Setup(rs => rs.CreateRentAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.CompletedTask); 

            
            var result = await rentController.ConfirmRent(1, 5); 

            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Car"));
        }
    }


}
