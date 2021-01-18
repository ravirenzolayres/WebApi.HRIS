using HrisApi.Controllers;
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
    public class ShiftWeeklyTests
    {
        private Mock<IFShiftWeekly> repoFShiftWeekly = new Mock<IFShiftWeekly>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private ShiftWeeklyController _ShiftWeeklyController;

        private int ShiftWeeklyId;
        private ShiftWeekly ShiftWeekly;
        private List<ShiftWeekly> ShiftWeeklyList;

        [TestInitialize]
        public void Setup()
        {
            ShiftWeeklyId = 1;

            ShiftWeekly = new ShiftWeekly
            {
                IDNo = 1,
                ShiftCode = "S003",
                Day = 1,
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            ShiftWeeklyList = new List<ShiftWeekly>()
            {
                new ShiftWeekly 
                {
                    IDNo = 1,
                    ShiftCode = "S003",
                    Day = 1,
                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            };

            repoFShiftWeekly.Setup(x => x.Get(ShiftWeeklyId)).ReturnsAsync(ShiftWeekly);
            repoFShiftWeekly.Setup(x => x.GetAll()).ReturnsAsync(ShiftWeeklyList);
            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task ShiftWeeklyController_GetById()
        {
            //arrange
            _ShiftWeeklyController = new ShiftWeeklyController(repoFShiftWeekly.Object, repoContext.Object);
            ///act
            var getShiftWeekly = await _ShiftWeeklyController.Get(ShiftWeeklyId);
            //assert
            Assert.AreEqual(ShiftWeeklyId, getShiftWeekly.IDNo);
        }

        [TestMethod]
        public async Task ShiftWeeklyController_GetAll()
        {
            //arrange
            _ShiftWeeklyController = new ShiftWeeklyController(repoFShiftWeekly.Object, repoContext.Object);
            ///act
            var getShiftWeeklyList = await _ShiftWeeklyController.GetAll();
            //assert
            Assert.AreSame(ShiftWeeklyList, getShiftWeeklyList);
        }
    }
}
