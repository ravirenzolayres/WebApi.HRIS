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
    public class EmployeeTypeTests
    {
        private Mock<IFEmployeeType> repoFEmployeeType = new Mock<IFEmployeeType>();
        private Mock<IDEmployeeType> repoDEmployeeType = new Mock<IDEmployeeType>();
        
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private EmployeeTypeController _EmployeeTypeController;
        private FEmployeeType _fEmployeeType;

        private int EmployeeTypeId;
        private string EmployeeTypeCode;

        private EmployeeType EmployeeType;
        private List<EmployeeType> EmployeeTypeList;

        [TestInitialize]
        public void Setup()
        {
            EmployeeTypeId = 1;
            EmployeeTypeCode = "ET001";

            EmployeeType = new EmployeeType
            {
                IDNo = 1,
                EmployeeTypeCode = "ET001",
                EmployeeTypeName = "Employee",
               
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            EmployeeTypeList = new List<EmployeeType>()
            {
                new EmployeeType
                {
                    IDNo = 1,
                    EmployeeTypeCode = "ET001",
                    EmployeeTypeName = "Employee",

                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            };

            repoFEmployeeType.Setup(x => x.Get(EmployeeTypeId)).ReturnsAsync(EmployeeType);
            repoFEmployeeType.Setup(x => x.GetAll()).ReturnsAsync(EmployeeTypeList);

            repoDEmployeeType.Setup(x => x.Get(It.IsAny<Func<EmployeeType, bool>>())).ReturnsAsync(EmployeeType);
            repoDEmployeeType.Setup(x => x.GetAll(It.IsAny<Func<EmployeeType, bool>>())).ReturnsAsync(EmployeeTypeList);
            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task EmployeeTypeController_GetById()
        {
            //arrange
            _EmployeeTypeController = new EmployeeTypeController(repoFEmployeeType.Object, repoContext.Object);
            ///act
            var getEmployeeType = await _EmployeeTypeController.Get(EmployeeTypeId);
            //assert
            Assert.AreEqual(EmployeeTypeId, getEmployeeType.IDNo);
        }

        [TestMethod]
        public async Task EmployeeTypeController_GetAll()
        {
            //arrange
            _EmployeeTypeController = new EmployeeTypeController(repoFEmployeeType.Object, repoContext.Object);
            ///act
            var getEmployeeTypeList = await _EmployeeTypeController.GetAll();
            //assert
            Assert.AreSame(EmployeeTypeList, getEmployeeTypeList);
        }


        [TestMethod]
        public async Task FEmployeeType_GetCode()
        {
            //arrange
            _fEmployeeType = new FEmployeeType(repoDEmployeeType.Object);
            ///act
            var getEmployeeTypeId = await _fEmployeeType.GetCode(EmployeeTypeCode);
            //assert
            Assert.AreEqual(EmployeeTypeId, getEmployeeTypeId);
        }

    }
}
