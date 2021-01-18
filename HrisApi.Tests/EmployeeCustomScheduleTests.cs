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
    public class EmployeeCustomScheduleTests
    {
        private Mock<IFEmployeeCustomSchedule> repoFEmployeeCustomSchedule = new Mock<IFEmployeeCustomSchedule>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private EmployeeCustomScheduleController _EmployeeCustomScheduleController;

        private int EmployeeCustomScheduleId;
        private EmployeeCustomSchedule EmployeeCustomSchedule;
        private List<EmployeeCustomSchedule> EmployeeCustomScheduleList;

        [TestInitialize]
        public void Setup()
        {
            EmployeeCustomScheduleId = 1;

            EmployeeCustomSchedule = new EmployeeCustomSchedule
            {
                IDNo = 1,
                EmployeeCode = "EC001",
                ShiftCode = "S003",
                Date = new DateTime(2020,12,04),
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            EmployeeCustomScheduleList = new List<EmployeeCustomSchedule>()
            {
                new EmployeeCustomSchedule 
                {
                    IDNo = 1,
                    EmployeeCode = "EC001",
                    ShiftCode = "S003",
                    Date = new DateTime(2020,12,04),
                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            };

            repoFEmployeeCustomSchedule.Setup(x => x.Get(EmployeeCustomScheduleId)).ReturnsAsync(EmployeeCustomSchedule);
            repoFEmployeeCustomSchedule.Setup(x => x.GetAll()).ReturnsAsync(EmployeeCustomScheduleList);
            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task EmployeeCustomScheduleController_GetById()
        {
            //arrange
            _EmployeeCustomScheduleController = new EmployeeCustomScheduleController(repoFEmployeeCustomSchedule.Object, repoContext.Object);
            ///act
            var getEmployeeCustomSchedule = await _EmployeeCustomScheduleController.Get(EmployeeCustomScheduleId);
            //assert
            Assert.AreEqual(EmployeeCustomScheduleId, getEmployeeCustomSchedule.IDNo);
        }

        [TestMethod]
        public async Task EmployeeCustomScheduleController_GetAll()
        {
            //arrange
            _EmployeeCustomScheduleController = new EmployeeCustomScheduleController(repoFEmployeeCustomSchedule.Object, repoContext.Object);
            ///act
            var getEmployeeCustomScheduleList = await _EmployeeCustomScheduleController.GetAll();
            //assert
            Assert.AreSame(EmployeeCustomScheduleList, getEmployeeCustomScheduleList);
        }
    }
}
