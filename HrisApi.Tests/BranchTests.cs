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
    public class BranchTests
    {
        private Mock<IFBranch> repoFBranch = new Mock<IFBranch>();
        private Mock<IDBranch> repoDBranch = new Mock<IDBranch>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private BranchController _BranchController;

        private int BranchId;
        private string BranchCode;
        private Branch Branch;
        private List<Branch> BranchList;

        [TestInitialize]
        public void Setup()
        {
            BranchId = 1;
            BranchCode = "B001";

            Branch = new Branch
            {
                IDNo = 1,
                BranchCode = "B001",
                BranchName = "Branch1",
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            BranchList = new List<Branch>()
            {
                new Branch { IDNo = 1, BranchCode = "B001",BranchName = "Branch1", IsActive = true,CreatedBy = "webadmin",CreatedOn = DateTime.Now },
            };

            repoFBranch.Setup(x => x.Get(BranchId)).ReturnsAsync(Branch);
            repoFBranch.Setup(x => x.GetAll()).ReturnsAsync(BranchList);
            repoFBranch.Setup(x => x.GetCode(It.IsAny<string>())).ReturnsAsync(BranchId);

            #region DBranch
            repoDBranch.Setup(x => x.Add(Branch)).ReturnsAsync(Branch);
            repoDBranch.Setup(x => x.Edit(Branch)).ReturnsAsync(Branch);
            repoDBranch.Setup(x => x.Delete(Branch)).ReturnsAsync(Branch);

            repoDBranch.Setup(x => x.Get(It.IsAny<Func<Branch, bool>>())).ReturnsAsync(Branch);
            repoDBranch.Setup(x => x.GetAll(It.IsAny<Func<Branch, bool>>())).ReturnsAsync(BranchList);
            #endregion

            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task BranchController_GetById()
        {
            //arrange
            _BranchController = new BranchController(repoFBranch.Object, repoContext.Object);
            ///act
            var getBranch = await _BranchController.Get(BranchId);
            //assert
            Assert.AreEqual(BranchId, getBranch.IDNo);
        }

        [TestMethod]
        public async Task BranchController_GetAll()
        {
            //arrange
            _BranchController = new BranchController(repoFBranch.Object, repoContext.Object);
            ///act
            var getBranchList = await _BranchController.GetAll();
            //assert
            Assert.AreSame(BranchList, getBranchList);
        }

        [TestMethod]
        public async Task FBranch_GetCode()
        {
            var fBranch = new FBranch(repoDBranch.Object);
            var getBranchId = await fBranch.GetCode(BranchCode);
            Assert.AreEqual(BranchId, getBranchId);
        }
    }
}
