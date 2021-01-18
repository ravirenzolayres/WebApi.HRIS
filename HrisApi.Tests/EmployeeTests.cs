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
    public class EmployeeTests
    {
        private Mock<IFEmployee> repoFEmployee = new Mock<IFEmployee>();
        private Mock<IDEmployee> repoDEmployee = new Mock<IDEmployee>();

        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private EmployeeController _EmployeeController;
        private FEmployee _fEmployee;

        private int EmployeeId;
        private string EmployeeCode;

        private Employee Employee;
        private List<Employee> EmployeeList;

        [TestInitialize]
        public void Setup()
        {
            EmployeeId = 1;
            EmployeeCode = "EC001";

            Employee = new Employee
            {
                IDNo = 1,
                EmployeeCode = "EC001",
                BioId = 101,
                CompanyCode = "COM001",
                BranchCode = "B001",
                DepartmentCode = "C001",
                PositionCode = "C001",
                EmployeeTypeCode = "ET001",
                PersonalInfoId = 1,
                EducationInfoId = 1,
               
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            EmployeeList = new List<Employee>()
            {
                new Employee
                {
                    IDNo = 1,
                    EmployeeCode = "EC001",
                    BioId = 101,
                    CompanyCode = "COM001",
                    BranchCode = "B001",
                    DepartmentCode = "C001",
                    PositionCode = "C001",
                    EmployeeTypeCode = "ET001",
                    PersonalInfoId = 1,
                    EducationInfoId = 1,

                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            };

            repoFEmployee.Setup(x => x.Get(EmployeeId)).ReturnsAsync(Employee);
            repoFEmployee.Setup(x => x.GetAll()).ReturnsAsync(EmployeeList);

            repoDEmployee.Setup(x => x.Get(It.IsAny<Func<Employee, bool>>())).ReturnsAsync(Employee);
            repoDEmployee.Setup(x => x.GetAll(It.IsAny<Func<Employee, bool>>())).ReturnsAsync(EmployeeList);

            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task EmployeeController_GetById()
        {
            //arrange
            _EmployeeController = new EmployeeController(repoFEmployee.Object, repoContext.Object);
            ///act
            var getEmployee = await _EmployeeController.Get(EmployeeId);
            //assert
            Assert.AreEqual(EmployeeId, getEmployee.IDNo);
        }

        [TestMethod]
        public async Task EmployeeController_GetAll()
        {
            //arrange
            _EmployeeController = new EmployeeController(repoFEmployee.Object, repoContext.Object);
            ///act
            var getEmployeeList = await _EmployeeController.GetAll();
            //assert
            Assert.AreSame(EmployeeList, getEmployeeList);
        }

        [TestMethod]
        public async Task FEmployee_GetCode()
        {
            //arrange
            _fEmployee = new FEmployee(repoDEmployee.Object);
            ///act
            var getEmployeeId = await _fEmployee.GetCode(EmployeeCode);
            //assert
            Assert.AreEqual(EmployeeId, getEmployeeId);
        }
    }
}
