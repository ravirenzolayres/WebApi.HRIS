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
    public class ShiftTests
    {
        private Mock<IFShift> repoFShift = new Mock<IFShift>();
        private Mock<IDShift> repoDShift = new Mock<IDShift>();

        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private ShiftController _ShiftController;
        private FShift _fShift;

        private int ShiftId;
        private string ShiftCode;

        private Shift Shift;
        private List<Shift> ShiftList;

        [TestInitialize]
        public void Setup()
        {
            ShiftId = 1;
            ShiftCode = "S003";

            Shift = new Shift
            {
                IDNo = 1,
                ShiftCode = "S003",
                ShiftName = "Shift3",
                ShiftIn = "08:30",
                ShiftOut = "17:30",
                ND1ShiftIn = "00:00",
                ND1ShiftOut = "00:00",
                ND2ShiftIn = "22:00",
                ND2ShiftOut = "06:00",
                ND3ShiftIn = "00:00",
                ND3ShiftOut = "00:00",

                HoursWork = 8,
                GracePeriod = 15,
                Brk = 60,
                IsRestday = false,

                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            ShiftList = new List<Shift>()
            {
                new Shift 
                {
                    IDNo = 1,
                    ShiftCode = "S003",
                    ShiftName = "Shift3",
                    ShiftIn = "08:30",
                    ShiftOut = "17:30",
                    ND1ShiftIn = "00:00",
                    ND1ShiftOut = "00:00",
                    ND2ShiftIn = "22:00",
                    ND2ShiftOut = "06:00",
                    ND3ShiftIn = "00:00",
                    ND3ShiftOut = "00:00",

                    HoursWork = 8,
                    GracePeriod = 15,
                    Brk = 60,
                    IsRestday = false,

                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            };

            repoFShift.Setup(x => x.Get(ShiftId)).ReturnsAsync(Shift);
            repoFShift.Setup(x => x.GetAll()).ReturnsAsync(ShiftList);

            repoDShift.Setup(x => x.Get(It.IsAny<Func<Shift,bool>>())).ReturnsAsync(Shift);
            repoDShift.Setup(x => x.GetAll(It.IsAny<Func<Shift,bool>>())).ReturnsAsync(ShiftList);

            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task ShiftController_GetById()
        {
            //arrange
            _ShiftController = new ShiftController(repoFShift.Object, repoContext.Object);
            ///act
            var getShift = await _ShiftController.Get(ShiftId);
            //assert
            Assert.AreEqual(ShiftId, getShift.IDNo);
        }

        [TestMethod]
        public async Task ShiftController_GetAll()
        {
            //arrange
            _ShiftController = new ShiftController(repoFShift.Object, repoContext.Object);
            ///act
            var getShiftList = await _ShiftController.GetAll();
            //assert
            Assert.AreSame(ShiftList, getShiftList);
        }

        [TestMethod]
        public async Task FShift_GetCode()
        {
            //arrange
            _fShift = new FShift(repoDShift.Object);
            ///act
            var getShiftId = await _fShift.GetCode(ShiftCode);
            //assert
            Assert.AreEqual(ShiftId, getShiftId);
        }
    }
}
