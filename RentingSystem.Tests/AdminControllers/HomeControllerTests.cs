using Microsoft.AspNetCore.Mvc;
using RentingSystem.Areas.Admin.Controllers;
namespace RentingSystem.Tests.AdminControllers
{

    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new HomeController();
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public void Dashboard_ShouldReturnViewResult()
        {
            var result = _controller.Dashboard();

            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }

}
