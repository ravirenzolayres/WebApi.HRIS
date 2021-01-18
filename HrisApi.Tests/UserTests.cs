using HrisApi.Controllers;
using HrisApi.Data;
using HrisApi.Data.Interface;
using HrisApi.Function;
using HrisApi.Function.Interface;
using HrisApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrisApi.Tests
{
    [TestClass]
    public class UserTests
    {
        private Mock<IFUser> repoFUser = new Mock<IFUser>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private UserController _UserController;

        private int UserId;
        private User User;
        private List<User> UserList;

        [TestInitialize]
        public void Setup()
        {
            UserId = 1;

            User = new User
            {
                IDNo = 1,
                Username = "webadmin",
                Password = "webadmin",
               
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            UserList = new List<User>()
            {
                new User
                {
                    IDNo = 1,
                    Username = "webadmin",
                    Password = "webadmin",

                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            };

            repoFUser.Setup(x => x.Get(UserId)).ReturnsAsync(User);
            repoFUser.Setup(x => x.GetAll()).ReturnsAsync(UserList);
            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task UserController_GetById()
        {
            //arrange
            _UserController = new UserController(repoFUser.Object, repoContext.Object);
            ///act
            var getUser = await _UserController.Get(UserId);
            //assert
            Assert.AreEqual(UserId, getUser.IDNo);
        }

        [TestMethod]
        public async Task UserController_GetAll()
        {
            //arrange
            _UserController = new UserController(repoFUser.Object, repoContext.Object);
            ///act
            var getUserList = await _UserController.GetAll();
            //assert
            Assert.AreSame(UserList, getUserList);
        }
    }
}
