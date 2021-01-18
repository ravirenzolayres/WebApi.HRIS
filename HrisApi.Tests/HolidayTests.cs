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
    public class HolidayTests
    {
        private Mock<IFHoliday> repoFHoliday = new Mock<IFHoliday>();
        private Mock<IDHoliday> repoDHoliday = new Mock<IDHoliday>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private HolidayController _HolidayController;
        private FHoliday _fHoliday;

        private int HolidayId;
        private string HolidayCode;

        private Holiday Holiday;
        private List<Holiday> HolidayList;

        [TestInitialize]
        public void Setup()
        {
            HolidayId = 1;
            HolidayCode = "H001";

            Holiday = new Holiday
            {
                IDNo = 1,
                HolidayCode = "H001",
                HolidayName = "CHRISTMAS DAY",
                Date = new DateTime(2020, 12, 25),
                IsFixed = true,
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            HolidayList = new List<Holiday>()
            {
                new Holiday
                {
                    IDNo = 1,
                    HolidayCode = "H001",
                    HolidayName = "CHRISTMAS DAY",
                    Date = new DateTime(2020,12,25),
                    IsFixed = true,

                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            };

            repoFHoliday.Setup(x => x.Get(HolidayId)).ReturnsAsync(Holiday);
            repoFHoliday.Setup(x => x.GetAll()).ReturnsAsync(HolidayList);

            repoDHoliday.Setup(x => x.Get(It.IsAny<Func<Holiday, bool>>())).ReturnsAsync(Holiday);
            repoDHoliday.Setup(x => x.GetAll(It.IsAny<Func<Holiday, bool>>())).ReturnsAsync(HolidayList);

            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task HolidayController_GetById()
        {
            //arrange
            _HolidayController = new HolidayController(repoFHoliday.Object, repoContext.Object);
            ///act
            var getHoliday = await _HolidayController.Get(HolidayId);
            //assert
            Assert.AreEqual(HolidayId, getHoliday.IDNo);
        }

        [TestMethod]
        public async Task HolidayController_GetAll()
        {
            //arrange
            _HolidayController = new HolidayController(repoFHoliday.Object, repoContext.Object);
            ///act
            var getHolidayList = await _HolidayController.GetAll();
            //assert
            Assert.AreSame(HolidayList, getHolidayList);
        }

        [TestMethod]
        public async Task FHoliday_GetCode()
        {
            //arrange
            _fHoliday = new FHoliday(repoDHoliday.Object);
            ///act
            var getHolidayId = await _fHoliday.GetCode(HolidayCode);
            //assert
            Assert.AreEqual(HolidayId, getHolidayId);
        }
    }
}
