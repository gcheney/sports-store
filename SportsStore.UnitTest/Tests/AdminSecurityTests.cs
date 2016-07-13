using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTest.Tests
{
    [TestClass]
    class AdminSecurityTests
    {
        [TestMethod]
        public void Can_Login_With_Valid_Credentials() 
        {
            //Arrange - creath a mock provider
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "password")).Returns(true);

            //Arrange - create the LoginViewModel
            LoginViewModel model = new LoginViewModel
            {
                UserName = "admin",
                Password = "password"
            };

            //Arrange - create the controller
            AccountController target = new AccountController(mock.Object);

            //Act - authenticate valid credentials
            ActionResult result = target.Login(model, "/returnURL");

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/returnURL", ((RedirectResult)result).Url);
        }

        [TestMethod]
        public void Cannot_Login_With_Invalid_Credentials()
        {
            //Arrange - creath a mock provider
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "password")).Returns(true);

            //Arrange - create the LoginViewModel
            LoginViewModel model = new LoginViewModel
            {
                UserName = "admin",
                Password = "badpass"
            };

            //Arrange - create the controller
            AccountController target = new AccountController(mock.Object);

            //Act - authenticate valid credentials
            ActionResult result = target.Login(model, "/returnURL");

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}
