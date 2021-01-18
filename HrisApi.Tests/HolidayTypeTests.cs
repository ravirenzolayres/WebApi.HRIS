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
    public class HolidayTypeTests
    {
        private Mock<IFHolidayType> repoFHolidayType = new Mock<IFHolidayType>();
        private Mock<IDHolidayType> repoDHolidayType = new Mock<IDHolidayType>();

        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private HolidayTypeController _HolidayTypeController;
        private FHolidayType _fHolidayType;

        private int HolidayTypeId;
        private string HolidayTypeCode;

        private HolidayType HolidayType;
        private List<HolidayType> HolidayTypeList;

        [TestInitialize]
        public void Setup()
        {
            HolidayTypeId = 1;
            HolidayTypeCode = "R";

            HolidayType = new HolidayType
            {
                IDNo = 1,
                HolidayTypeCode = "R",
                HolidayTypeName = "REGULAR",
                
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            HolidayTypeList = new List<HolidayType>()
            {
                new HolidayType
                {
                    IDNo = 1,
                    HolidayTypeCode = "R",
                    HolidayTypeName = "REGULAR",

                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            };

            repoFHolidayType.Setup(x => x.Get(HolidayTypeId)).ReturnsAsync(HolidayType);
            repoFHolidayType.Setup(x => x.GetAll()).ReturnsAsync(HolidayTypeList);

            repoDHolidayType.Setup(x => x.Get(It.IsAny<Func<HolidayType,bool>>())).ReturnsAsync(HolidayType);
            repoDHolidayType.Setup(x => x.GetAll(It.IsAny<Func<HolidayType,bool>>())).ReturnsAsync(HolidayTypeList);

            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task HolidayTypeController_GetById()
        {
            //arrange
            _HolidayTypeController = new HolidayTypeController(repoFHolidayType.Object, repoContext.Object);
            ///act
            var getHolidayType = await _HolidayTypeController.Get(HolidayTypeId);
            //assert
            Assert.AreEqual(HolidayTypeId, getHolidayType.IDNo);
        }

        [TestMethod]
        public async Task HolidayTypeController_GetAll()
        {
            //arrange
            _HolidayTypeController = new HolidayTypeController(repoFHolidayType.Object, repoContext.Object);
            ///act
            var getHolidayTypeList = await _HolidayTypeController.GetAll();
            //assert
            Assert.AreSame(HolidayTypeList, getHolidayTypeList);
        }

        [TestMethod]
        public async Task FHolidayType_GetCode()
        {
            //arrange
            _fHolidayType = new FHolidayType(repoDHolidayType.Object);
            ///act
            var getHolidayTypeId = await _fHolidayType.GetCode(HolidayTypeCode);
            //assert
            Assert.AreEqual(HolidayTypeId, getHolidayTypeId);
        }

    }
}
