using HrisApi.Context;
using HrisApi.Controllers;
using HrisApi.Data;
using HrisApi.Data.DBase;
using HrisApi.Data.Interface;
using HrisApi.Function;
using HrisApi.Function.Interface;
using HrisApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrisApi.Tests
{
    [TestClass]
    public class AccessTests
    {
        private Mock<IFAccess> repoFAccess = new Mock<IFAccess>();
        private Mock<IDAccess> repoDAccess = new Mock<IDAccess>();
        private Mock<IDBase<Access>> repoDBase = new Mock<IDBase<Access>>();

        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private AccessController _accessController;
        private FAccess _fAccess;

        private int accessId;
        private string accessCode;
        private Access access;
        private List<Access> accessList;

        [TestInitialize]
        public void Setup()
        {
            accessId = 1;
            accessCode = "AC01";

            access = new Access
            {
                IDNo = 1,
                AccessCode = "AC01",
                AccessName = "ALL-ACCESS",
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            accessList = new List<Access>()
            {
                new Access { IDNo = 1, AccessCode = "AC01",AccessName = "ALL-ACCESS", IsActive = true,CreatedBy = "webadmin",CreatedOn = DateTime.Now },
            };

            #region FAccess
            repoFAccess.Setup(x => x.Add(It.IsAny<string>(),access)).ReturnsAsync(access);
            repoFAccess.Setup(x => x.Edit(It.IsAny<string>(),access)).ReturnsAsync(access);
            repoFAccess.Setup(x => x.Delete(It.IsAny<string>(),access)).ReturnsAsync(access);
            repoFAccess.Setup(x => x.Get(accessId)).ReturnsAsync(access);
            repoFAccess.Setup(x => x.GetAll()).ReturnsAsync(accessList);
            repoFAccess.Setup(x => x.Get(accessId)).ReturnsAsync(access);
            repoFAccess.Setup(x => x.GetCode(It.IsAny<string>())).ReturnsAsync(accessId);

            #endregion

            #region DAccess
            repoDAccess.Setup(x => x.Add(access)).ReturnsAsync(access);
            repoDAccess.Setup(x => x.Edit(access)).ReturnsAsync(access);
            repoDAccess.Setup(x => x.Delete(access)).ReturnsAsync(access);

            repoDAccess.Setup(x => x.Get(It.IsAny<Func<Access,bool>>())).ReturnsAsync(access);
            repoDAccess.Setup(x => x.GetAll(It.IsAny<Func<Access, bool>>())).ReturnsAsync(accessList);
            #endregion

            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());

        }

        [TestMethod]
        public async Task AccessController_GetById()
        {
            //arrange
            _fAccess = new FAccess(repoDAccess.Object);
            _accessController = new AccessController(_fAccess, repoContext.Object);
            ///act
            var getAccess = await _accessController.Get(accessId);
            //assert
            Assert.AreEqual(accessId, getAccess.IDNo);
        }

        [TestMethod]
        public async Task AccessController_GetAll()
        {
            //arrange
            _accessController = new AccessController(repoFAccess.Object, repoContext.Object);
            ///act
            var getAccessList = await _accessController.GetAll();
            //assert
            Assert.AreSame(accessList, getAccessList);
        }

        [TestMethod]
            public async Task FAccess_GetCode()
        {
            _fAccess = new FAccess(repoDAccess.Object);
            var getAccessId = await _fAccess.GetCode(accessCode);
            Assert.AreEqual(accessId, getAccessId);
        }
    }
}
