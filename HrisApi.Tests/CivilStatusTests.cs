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
    public class CivilStatusTests
    {
        private Mock<IFCivilStatus> repoFCivilStatus = new Mock<IFCivilStatus>();
        private Mock<IDCivilStatus> repoDCivilStatus = new Mock<IDCivilStatus>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private CivilStatusController _CivilStatusController;
        private FCivilStatus _fCivilStatus;

        private int CivilStatusId;
        private string CivilStatusCode;

        private CivilStatus CivilStatus;
        private List<CivilStatus> CivilStatusList;

        [TestInitialize]
        public void Setup()
        {
            CivilStatusId = 1;
            CivilStatusCode = "C001";

            CivilStatus = new CivilStatus
            {
                IDNo = 1,
                CivilStatusCode = "C001",
                CivilStatusName = "CivilStatus1",
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            CivilStatusList = new List<CivilStatus>()
            {
                new CivilStatus { IDNo = 1, CivilStatusCode = "C001",CivilStatusName = "CivilStatus1", IsActive = true,CreatedBy = "webadmin",CreatedOn = DateTime.Now },
            };

            repoFCivilStatus.Setup(x => x.Get(CivilStatusId)).ReturnsAsync(CivilStatus);
            repoFCivilStatus.Setup(x => x.GetAll()).ReturnsAsync(CivilStatusList);
            repoFCivilStatus.Setup(x => x.GetCode(It.IsAny<string>())).ReturnsAsync(CivilStatusId);

            #region DCivilStatus
            repoDCivilStatus.Setup(x => x.Add(CivilStatus)).ReturnsAsync(CivilStatus);
            repoDCivilStatus.Setup(x => x.Edit(CivilStatus)).ReturnsAsync(CivilStatus);
            repoDCivilStatus.Setup(x => x.Delete(CivilStatus)).ReturnsAsync(CivilStatus);

            repoDCivilStatus.Setup(x => x.Get(It.IsAny<Func<CivilStatus, bool>>())).ReturnsAsync(CivilStatus);
            repoDCivilStatus.Setup(x => x.GetAll(It.IsAny<Func<CivilStatus, bool>>())).ReturnsAsync(CivilStatusList);
            #endregion

            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task CivilStatusController_GetById()
        {
            //arrange
            _CivilStatusController = new CivilStatusController(repoFCivilStatus.Object, repoContext.Object);
            ///act
            var getCivilStatus = await _CivilStatusController.Get(CivilStatusId);
            //assert
            Assert.AreEqual(CivilStatusId, getCivilStatus.IDNo);
        }

        [TestMethod]
        public async Task CivilStatusController_GetAll()
        {
            //arrange
            _CivilStatusController = new CivilStatusController(repoFCivilStatus.Object, repoContext.Object);
            ///act
            var getCivilStatusList = await _CivilStatusController.GetAll();
            //assert
            Assert.AreSame(CivilStatusList, getCivilStatusList);
        }

        [TestMethod]
        public async Task FCivilStatus_GetCode()
        {
            //arrange
            _fCivilStatus = new FCivilStatus(repoDCivilStatus.Object);
            ///act
            var getCivilStatusId = await _fCivilStatus.GetCode(CivilStatusCode);
            //assert
            Assert.AreEqual(CivilStatusId, getCivilStatusId);
        }
    }
}
