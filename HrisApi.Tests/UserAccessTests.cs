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
    public class UserAccessTests
    {
        private Mock<IFUserAccess> repoFUserAccess = new Mock<IFUserAccess>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private UserAccessController _UserAccessController;

        private int UserAccessId;
        private UserAccess UserAccess;
        private List<UserAccess> UserAccessList;

        [TestInitialize]
        public void Setup()
        {
            UserAccessId = 1;

            UserAccess = new UserAccess
            {
                IDNo = 1,
                Username = "webadmin",
                AccessCode = "AC01",
               
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now
            };

            UserAccessList = new List<UserAccess>()
            {
                new UserAccess
                {
                    IDNo = 1,
                    Username = "webadmin",
                    AccessCode = "AC01",

                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now
                }
            };

            repoFUserAccess.Setup(x => x.Get(UserAccessId)).ReturnsAsync(UserAccess);
            repoFUserAccess.Setup(x => x.GetAll()).ReturnsAsync(UserAccessList);
            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task UserAccessController_GetById()
        {
            //arrange
            _UserAccessController = new UserAccessController(repoFUserAccess.Object, repoContext.Object);
            ///act
            var getUserAccess = await _UserAccessController.Get(UserAccessId);
            //assert
            Assert.AreEqual(UserAccessId, getUserAccess.IDNo);
        }

        [TestMethod]
        public async Task UserAccessController_GetAll()
        {
            //arrange
            _UserAccessController = new UserAccessController(repoFUserAccess.Object, repoContext.Object);
            ///act
            var getUserAccessList = await _UserAccessController.GetAll();
            //assert
            Assert.AreSame(UserAccessList, getUserAccessList);
        }
    }
}
