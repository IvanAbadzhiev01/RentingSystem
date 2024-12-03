using Moq;
using NUnit.Framework;
using RentingSystem.Controllers;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Car;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RentingSystem.Core.Enumerations;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace RentingSystem.Tests.Controllers
{
    [TestFixture]
    public class CarControllerTests
    {
        private CarController _controller;
        private Mock<ICarService> _mockCarService;
        private Mock<IDealerService> _mockDealerService;

        [SetUp]
        public void SetUp()
        {
            _mockCarService = new Mock<ICarService>();
            _mockDealerService = new Mock<IDealerService>();
            _controller = new CarController(_mockCarService.Object, _mockDealerService.Object);

            var tempData = new Mock<ITempDataDictionary>();
            _controller.TempData = tempData.Object;
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public async Task All_ShouldReturnViewResult_WhenCalled()
        {

            var query = new AllCarModel();
            var carQueryModel = new CarQueryServiceModel(); // Може да се използва реален модел
            _mockCarService.Setup(service => service.AllAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CarSorting>(), It.IsAny<int>(), It.IsAny<int>()))
                           .ReturnsAsync(carQueryModel);
            _mockCarService.Setup(service => service.AllCategoriesNamesAsync())
                           .ReturnsAsync(new List<string> { "Category1", "Category2" });

            var result = await _controller.All(query);

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult?.Model, Is.EqualTo(query));
        }

        [Test]
        public async Task MyCar_ShouldReturnViewResult_WhenUserIsDealer()
        {

            var userId = "user123";
            var dealerId = 1;
            var carModels = new List<CarServiceModel>
                {
                    new CarServiceModel { Id = 1, Make = "Car 1" }
                };


            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),

                };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            _mockDealerService.Setup(d => d.ExistsByIdAsync(userId)).ReturnsAsync(true);
            _mockDealerService.Setup(d => d.GetDealerIdAsync(userId)).ReturnsAsync(dealerId);
            _mockCarService.Setup(s => s.AllCarsByDealerIdAsync(dealerId)).ReturnsAsync(carModels);

            var result = await _controller.MyCar();

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult?.Model, Is.EqualTo(carModels));
        }

        [Test]
        public async Task MyCar_ShouldRedirectToAdmin_WhenUserIsAdmin()
        {
            var userId = "admin123";
            _mockDealerService.Setup(d => d.ExistsByIdAsync(userId)).ReturnsAsync(false);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, "Administrator")
                };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.MyCar();

            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult?.ActionName, Is.EqualTo("MyCar"));
            Assert.That(redirectResult?.ControllerName, Is.EqualTo("Car"));
            Assert.That(redirectResult?.RouteValues["area"], Is.EqualTo("Admin"));
        }

        [Test]
        public async Task Details_ShouldReturnViewResult_WhenCarExists()
        {
            int carId = 1;
            var carDetails = new CarDetailsServiceModel
            {
                Id = carId,
                Make = "Car",
                Model = "1",
                Title = "Car 1",
                Description = "Description of Car 1",
                FuelType = "Test",
                Shift = "Test",
                Seat = 5,
                ImageUrl = "car1.jpg",
                Year = 2020,
                Dealer = new DealerServiceModel
                {
                    FullName = "Dealer 1",
                    PhoneNumber = "1234567890",
                    Email = "dealer1@example.com"
                }
            };

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.CarDetailsByIdAsync(carId)).ReturnsAsync(carDetails);


            var result = await _controller.Details(carId, "Car12020");

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult?.Model, Is.EqualTo(carDetails));
        }

        [Test]
        public async Task Details_ShouldReturnNotFound_WhenCarDoesNotExist()
        {
            int carId = 1;

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(false);

            var result = await _controller.Details(carId, "Car 1");

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Add_ShouldRedirectToBecomeDealer_WhenUserIsNotDealer()
        {
            var userId = "user123";
            _mockDealerService.Setup(d => d.ExistsByIdAsync(userId)).ReturnsAsync(false);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),

                };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Add();

            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult?.ActionName, Is.EqualTo("Become"));
            Assert.That(redirectResult?.ControllerName, Is.EqualTo("Dealer"));
        }

        [Test]
        public async Task Delete_ShouldReturnViewResult_WhenCarExists()
        {
            var userId = "user123";
            int carId = 1;
            var carDetails = new CarDetailsServiceModel
            {
                Id = carId,
                Make = "Car",
                Model = "1",
                Title = "Car 1",
                Description = "Description of Car 1",
                FuelType = "Test",
                Shift = "Test",
                Seat = 5,
                ImageUrl = "car1.jpg",
                Year = 2020,
                Dealer = new DealerServiceModel
                {
                    FullName = "Dealer 1",
                    PhoneNumber = "1234567890",
                    Email = "dealer1@example.com"
                }
            };

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.HasDealerWithIdAsync(carId, userId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.CarDetailsByIdAsync(carId)).ReturnsAsync(carDetails);

            var claims = new List<Claim>
                 {
                     new Claim(ClaimTypes.NameIdentifier, userId),

                 };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Delete(carId);

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult?.Model.GetType(), Is.EqualTo(typeof(CarDetailsViewModel)));
        }

        [Test]
        public async Task Delete_ShouldReturnBadRequest_WhenCarDoesNotExist()
        {
            int carId = 1;

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(false);

            var result = await _controller.Delete(carId);

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task Add_Post_ShouldReturnViewResult_WhenModelIsInvalid()
        {
            var userId = "user123";
            _mockDealerService.Setup(d => d.ExistsByIdAsync(userId)).ReturnsAsync(true);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, userId)
    };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var model = new CarFormModel { CategoryId = 999 }; // Несъществуваща категория
            _mockCarService.Setup(s => s.CategoryExistsAsync(model.CategoryId)).ReturnsAsync(false);

            var result = await _controller.Add(model);

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult?.Model, Is.EqualTo(model));
        }

        [Test]
        public async Task Edit_Get_ShouldReturnBadRequest_WhenCarDoesNotExist()
        {
            int carId = 1;
            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(false);

            var result = await _controller.Edit(carId);

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task Edit_Post_ShouldReturnUnauthorized_WhenUserIsNotDealerOrAdmin()
        {
            int carId = 1;
            var userId = "user123";
            var model = new CarFormModel();

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.HasDealerWithIdAsync(carId, userId)).ReturnsAsync(false);

            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, userId)
                        };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Edit(carId, model);

            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }

        [Test]
        public async Task Edit_Post_ShouldRedirectToDetails_WhenEditIsSuccessful()
        {

            int carId = 1;
            string userId = "user123";
            var carFormModel = new CarFormModel
            {
                CategoryId = 1,
                Make = "Car",
                Model = "1",
                Year = 2022
            };

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.HasDealerWithIdAsync(carId, userId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.CategoryExistsAsync(carFormModel.CategoryId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.EditAsync(carId, carFormModel)).Returns(Task.CompletedTask);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };


            var result = await _controller.Edit(carId, carFormModel);


            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult?.ActionName, Is.EqualTo("Details"));
            Assert.That(redirectResult?.RouteValues?["id"], Is.EqualTo(carId));
        }


        [Test]
        public async Task Delete_Post_ShouldReturnUnauthorized_WhenUserIsNotDealerOrAdmin()
        {
            var userId = "user123";
            var model = new CarDetailsViewModel { Id = 1 };

            _mockCarService.Setup(s => s.ExistsAsync(model.Id)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.HasDealerWithIdAsync(model.Id, userId)).ReturnsAsync(false);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, userId)
    };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Delete(model);

            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }

        [Test]
        public async Task Delete_Post_ShouldRedirectToAll_WhenDeleteIsSuccessful()
        {

            var userId = "user123";
            int carId = 1;

            var model = new CarDetailsViewModel { Id = carId };

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.HasDealerWithIdAsync(carId, userId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.DeleteAsync(carId)).Returns(Task.CompletedTask);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Delete(model);

            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult?.ActionName, Is.EqualTo("All"));
        }

        [Test]
        public async Task Edit_Post_ShouldReturnBadRequest_WhenCarDoesNotExist()
        {
            int carId = 1;
            var carFormModel = new CarFormModel();

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(false);

            var result = await _controller.Edit(carId, carFormModel);

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task Delete_Post_ShouldReturnBadRequest_WhenCarDoesNotExist()
        {
            int carId = 1;

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(false);

            var result = await _controller.Delete(new CarDetailsViewModel { Id = carId });

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task EditGet_Post_ShouldReturnUnauthorized_WhenUserIsNotDealerOrAdmin()
        {
            int carId = 1;
            string userId = "user123";
            var carFormModel = new CarFormModel();

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.HasDealerWithIdAsync(carId, userId)).ReturnsAsync(false);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, userId),
    };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Edit(carId);

            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }

        [Test]
        public async Task Add_Get_ShouldReturnViewWithModel_WhenUserIsDealer()
        {
            string userId = "user123";
            var categories = new List<CarCategoryServiceModel>
                                {
                                    new CarCategoryServiceModel { Id = 1, Name = "SUV" },
                                    new CarCategoryServiceModel { Id = 2, Name = "Sedan" }
                                };

            _mockDealerService.Setup(s => s.ExistsByIdAsync(userId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.AllCategoriesAsync()).ReturnsAsync(categories);

            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Add();

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            var model = viewResult?.Model as CarFormModel;
            Assert.That(model, Is.Not.Null);
            Assert.That(model.Categories, Is.EqualTo(categories));
        }

        [Test]
        public async Task Add_Post_ShouldRedirectToBecome_WhenUserIsNotDealer()
        {
            string userId = "user123";
            var carFormModel = new CarFormModel();

            _mockDealerService.Setup(s => s.ExistsByIdAsync(userId)).ReturnsAsync(false);

            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Add(carFormModel);

            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult?.ActionName, Is.EqualTo(nameof(DealerController.Become)));
            Assert.That(redirectResult?.ControllerName, Is.EqualTo("Dealer"));
        }

        [Test]
        public async Task Add_Post_ShouldReturnViewWithModelError_WhenCategoryDoesNotExist()
        {
            string userId = "user123";
            var carFormModel = new CarFormModel { CategoryId = 99 };

            _mockDealerService.Setup(s => s.ExistsByIdAsync(userId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.CategoryExistsAsync(carFormModel.CategoryId)).ReturnsAsync(false);

            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Add(carFormModel);

            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(!_controller.ModelState.IsValid);
            Assert.That(_controller.ModelState[nameof(carFormModel.CategoryId)].Errors.First().ErrorMessage, Is.EqualTo(RentingSystem.Infrastructure.Constants.ErrorConstants.CategoryNotExist));
        }

        [Test]
        public async Task Add_Post_ShouldRedirectToAll_WhenCarIsAddedSuccessfully()
        {
            string userId = "user123";
            int dealerId = 5;
            int newCarId = 10;
            var carFormModel = new CarFormModel { CategoryId = 1 };

            _mockDealerService.Setup(s => s.ExistsByIdAsync(userId)).ReturnsAsync(true);
            _mockDealerService.Setup(s => s.GetDealerIdAsync(userId)).ReturnsAsync(dealerId);
            _mockCarService.Setup(s => s.CategoryExistsAsync(carFormModel.CategoryId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.CreateAsync(carFormModel, dealerId)).ReturnsAsync(newCarId);

            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Add(carFormModel);

            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult?.ActionName, Is.EqualTo(nameof(_controller.All)));
        }

        [Test]
        public async Task Delete_Post_ShouldReturnUnauthorized_WhenUserIsNotAuthorized()
        {
            int carId = 1;
            string userId = "user123";

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.HasDealerWithIdAsync(carId, userId)).ReturnsAsync(false);

            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Delete(new CarDetailsViewModel { Id = carId });

            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }

        [Test]
        public async Task Delete_Get_ShouldReturnUnauthorized_WhenUserIsNotAuthorized()
        {
            int carId = 1;
            string userId = "user123";

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.HasDealerWithIdAsync(carId, userId)).ReturnsAsync(false);

            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.Delete(carId);

            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }

        [Test]
        public async Task MyCars_Get_ShouldReturnViewWithCars_WhenUserHasCars()
        {
            string userId = "user123";
            var cars = new List<CarServiceModel>
                                {
                                    new CarServiceModel { Id = 1, Model = "Car 1" },
                                    new CarServiceModel { Id = 2, Model = "Car 2" }
                                };

            _mockCarService.Setup(s => s.AllCarsByUserIdAsync(userId)).ReturnsAsync(cars);

            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var result = await _controller.MyCar();

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            var model = viewResult?.Model as IEnumerable<CarServiceModel>;
            Assert.That(model, Is.Not.Null);
            Assert.That(model, Is.EqualTo(cars));
        }

        [Test]
        public async Task Details_Get_ShouldReturnBadRequest_WhenInformationDoesNotMatch()
        {
            int carId = 1;
            string expectedInformation = "expected-info";
            var carDetails = new CarDetailsServiceModel
            {
                Id = carId,
                Make = "Car",
                Model = "1",
                Year = 2022

            };

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.CarDetailsByIdAsync(carId)).ReturnsAsync(carDetails);

            var result = await _controller.Details(carId, expectedInformation);

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task Edit_Get_ShouldReturnViewWithModel_WhenCarExists()
        {
            string userId = "user123";
            int carId = 1;
            var carFormModel = new CarFormModel { Model = "Car 1", CategoryId = 1 };

            var claims = new List<Claim>
                         {
                             new Claim(ClaimTypes.NameIdentifier, userId),

                         };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _controller.ControllerContext = new ControllerContext
                        {
                            HttpContext = new DefaultHttpContext { User = user }
                        };

            _mockCarService.Setup(s => s.ExistsAsync(carId)).ReturnsAsync(true);
            _mockCarService.Setup(s => s.HasDealerWithIdAsync(carId, _controller.User.Id())).ReturnsAsync(true);
            _mockCarService.Setup(s => s.GetCarFormModelByIdAsync(carId)).ReturnsAsync(carFormModel);

            var result = await _controller.Edit(carId);

            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            var model = viewResult?.Model as CarFormModel;
            Assert.That(model, Is.Not.Null);
            Assert.That(model, Is.EqualTo(carFormModel));
        }

        [Test]
        public async Task Edit_Post_ShouldReturnBadRequest_WhenCategoryDoesNotExist()
        {
            int carId = 1;
            var carFormModel = new CarFormModel { CategoryId = 99 };

            _mockCarService.Setup(s => s.CategoryExistsAsync(carFormModel.CategoryId)).ReturnsAsync(false);

            var result = await _controller.Edit(carId, carFormModel);

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

    }
}
