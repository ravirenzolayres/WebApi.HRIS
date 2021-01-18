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
    public class GenderTests
    {
        private Mock<IFGender> repoFGender = new Mock<IFGender>();
        private Mock<IDGender> repoDGender = new Mock<IDGender>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private GenderController _GenderController;
        private FGender _fGender;

        private int GenderId;
        private string GenderCode;

        private Gender Gender;
        private List<Gender> GenderList;

        [TestInitialize]
        public void Setup()
        {
            GenderId = 1;
            GenderCode = "M";
            Gender = new Gender
            {
                IDNo = 1,
                GenderCode = "M",
                GenderName = "MALE",
               
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            GenderList = new List<Gender>()
            {
                new Gender
                {
                    IDNo = 1,
                    GenderCode = "M",
                    GenderName = "MALE",

                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            };

            repoFGender.Setup(x => x.Get(GenderId)).ReturnsAsync(Gender);
            repoFGender.Setup(x => x.GetAll()).ReturnsAsync(GenderList);

            repoDGender.Setup(x => x.Get(It.IsAny<Func<Gender, bool>>())).ReturnsAsync(Gender);
            repoDGender.Setup(x => x.GetAll(It.IsAny<Func<Gender, bool>>())).ReturnsAsync(GenderList);
            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task GenderController_GetById()
        {
            //arrange
            _GenderController = new GenderController(repoFGender.Object, repoContext.Object);
            ///act
            var getGender = await _GenderController.Get(GenderId);
            //assert
            Assert.AreEqual(GenderId, getGender.IDNo);
        }

        [TestMethod]
        public async Task GenderController_GetAll()
        {
            //arrange
            _GenderController = new GenderController(repoFGender.Object, repoContext.Object);
            ///act
            var getGenderList = await _GenderController.GetAll();
            //assert
            Assert.AreSame(GenderList, getGenderList);
        }


        [TestMethod]
        public async Task FGender_GetCode()
        {
            //arrange
            _fGender = new FGender(repoDGender.Object);
            ///act
            var getGenderId = await _fGender.GetCode(GenderCode);
            //assert
            Assert.AreEqual(GenderId, getGenderId);
        }
    }
}
