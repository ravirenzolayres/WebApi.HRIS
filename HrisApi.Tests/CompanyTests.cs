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
    public class CompanyTests
    {
        private Mock<IFCompany> repoFCompany = new Mock<IFCompany>();
        private Mock<IDCompany> repoDCompany = new Mock<IDCompany>();

        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private CompanyController _CompanyController;
        private FCompany _fCompany;

        private int CompanyId;
        private string CompanyCode;
        private Company Company;
        private List<Company> CompanyList;

        [TestInitialize]
        public void Setup()
        {
            CompanyId = 1;
            CompanyCode = "COM001";

            Company = new Company
            {
                IDNo = 1,
                CompanyCode = "COM001",
                CompanyName = "Company1",
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            CompanyList = new List<Company>()
            {
                new Company { IDNo = 1, CompanyCode = "COM001",CompanyName = "Company1", IsActive = true,CreatedBy = "webadmin",CreatedOn = DateTime.Now },
            };

            repoFCompany.Setup(x => x.Get(CompanyId)).ReturnsAsync(Company);
            repoFCompany.Setup(x => x.GetAll()).ReturnsAsync(CompanyList);
            repoFCompany.Setup(x => x.GetCode(It.IsAny<string>())).ReturnsAsync(CompanyId);

            repoDCompany.Setup(x => x.Get(It.IsAny<Func<Company, bool>>())).ReturnsAsync(Company);
            repoDCompany.Setup(x => x.GetAll(It.IsAny<Func<Company, bool>>())).ReturnsAsync(CompanyList);

            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task CompanyController_GetById()
        {
            //arrange
            _CompanyController = new CompanyController(repoFCompany.Object, repoContext.Object);
            ///act
            var getCompany = await _CompanyController.Get(CompanyId);
            //assert
            Assert.AreEqual(CompanyId, getCompany.IDNo);
        }

        [TestMethod]
        public async Task CompanyController_GetAll()
        {
            //arrange
            _CompanyController = new CompanyController(repoFCompany.Object, repoContext.Object);
            ///act
            var getCompanyList = await _CompanyController.GetAll();
            //assert
            Assert.AreSame(CompanyList, getCompanyList);
        }

        [TestMethod]
        public async Task FCompany_GetCode()
        {
            //arrange
            _fCompany = new FCompany(repoDCompany.Object);
            ///act
            var getCompanyId = await _fCompany.GetCode(CompanyCode);
            //assert
            Assert.AreEqual(CompanyId, getCompanyId);
        }

    }
}
