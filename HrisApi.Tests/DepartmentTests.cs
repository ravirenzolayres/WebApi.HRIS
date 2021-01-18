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
    public class DepartmentTests
    {
        private Mock<IFDepartment> repoFDepartment = new Mock<IFDepartment>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private DepartmentController _DepartmentController;

        private int DepartmentId;
        private Department Department;
        private List<Department> DepartmentList;

        [TestInitialize]
        public void Setup()
        {
            DepartmentId = 1;

            Department = new Department
            {
                IDNo = 1,
                DepartmentCode = "D001",
                DepartmentName = "Department1",
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            DepartmentList = new List<Department>()
            {
                new Department { IDNo = 1, DepartmentCode = "D001",DepartmentName = "Department1", IsActive = true,CreatedBy = "webadmin",CreatedOn = DateTime.Now }
            };

            repoFDepartment.Setup(x => x.Get(DepartmentId)).ReturnsAsync(Department);
            repoFDepartment.Setup(x => x.GetAll()).ReturnsAsync(DepartmentList);
            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task DepartmentController_GetById()
        {
            //arrange
            _DepartmentController = new DepartmentController(repoFDepartment.Object, repoContext.Object);
            ///act
            var getDepartment = await _DepartmentController.Get(DepartmentId);
            //assert
            Assert.AreEqual(DepartmentId, getDepartment.IDNo);
        }

        [TestMethod]
        public async Task DepartmentController_GetAll()
        {
            //arrange
            _DepartmentController = new DepartmentController(repoFDepartment.Object, repoContext.Object);
            ///act
            var getDepartmentList = await _DepartmentController.GetAll();
            //assert
            Assert.AreSame(DepartmentList, getDepartmentList);
        }
    }
}
