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
    public class BioLogsTests
    {
        private Mock<IFBioLogs> repoFBioLogs = new Mock<IFBioLogs>();
        private Mock<IDBioLogs> repoDBioLogs = new Mock<IDBioLogs>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private BioLogsController _BioLogsController;
        private FBioLogs _fBioLogs;

        private int BioLogsId;
        private int BioId;

        private BioLogs BioLogs;
        private List<BioLogs> BioLogsList;

        [TestInitialize]
        public void Setup()
        {
            BioLogsId = 1;
            BioId = 1;
            BioLogs = new BioLogs
            {
                IDNo = 1,
                EmployeeCode = "E001",
                BioId = 1,
                Date = DateTime.Now,
                Time = DateTime.Now.ToShortTimeString(),
                LogType = 0,
                
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            BioLogsList = new List<BioLogs>()
            {
                new BioLogs
                {
                    IDNo = 1,
                    EmployeeCode = "E001",
                    BioId = 1,
                    Date = DateTime.Now,
                    Time = DateTime.Now.ToShortTimeString(),
                    LogType = 0,

                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            };

            repoFBioLogs.Setup(x => x.Get(BioLogsId)).ReturnsAsync(BioLogs);
            repoFBioLogs.Setup(x => x.GetAll()).ReturnsAsync(BioLogsList);

            repoDBioLogs.Setup(x => x.Get(It.IsAny<Func<BioLogs, bool>>())).ReturnsAsync(BioLogs);
            repoDBioLogs.Setup(x => x.GetAll(It.IsAny<Func<BioLogs, bool>>())).ReturnsAsync(BioLogsList);
            
            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task BioLogsController_GetById()
        {
            //arrange
            _BioLogsController = new BioLogsController(repoFBioLogs.Object, repoContext.Object);
            ///act
            var getBioLogs = await _BioLogsController.Get(BioLogsId);
            //assert
            Assert.AreEqual(BioLogsId, getBioLogs.IDNo);
        }

        [TestMethod]
        public async Task BioLogsController_GetAll()
        {
            //arrange
            _BioLogsController = new BioLogsController(repoFBioLogs.Object, repoContext.Object);
            ///act
            var getBioLogsList = await _BioLogsController.GetAll();
            //assert
            Assert.AreSame(BioLogsList, getBioLogsList);
        }
    }
}
