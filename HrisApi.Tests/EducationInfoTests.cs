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
    public class EducationInfoTests
    {
        private Mock<IFEducationInfo> repoFEducationInfo = new Mock<IFEducationInfo>();
        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private EducationInfoController _EducationInfoController;

        private int EducationInfoId;
        private EducationInfo EducationInfo;
        private List<EducationInfo> EducationInfoList;

        [TestInitialize]
        public void Setup()
        {
            EducationInfoId = 1;

            EducationInfo = new EducationInfo
            {
                IDNo = 1,
                EmployeeCode = "1",

                ESName = "ESName1",
                HSName = "HSName1",
                VSName = "VSName1",
                CSName = "CSName1",
                PGSName = "PGSName1",

                ESAddress = "ESAddress1",
                HSAddress = "HSAddress1",
                VSAddress = "VSName1",
                CSAddress = "CSAddress1",
                PGSAddress = "PGSAddress1",

                VSCourse = "VSCourse1",
                CSCourse = "CSCourse1",
                PGSCourse = "PGSCourse1",

                ESInclusiveStartYear = "ESInclusiveStartYear1",
                HSInclusiveStartYear = "HSInclusiveStartYear1",
                VSInclusiveStartYear = "VSInclusiveStartYear1",
                CSInclusiveStartYear = "CSInclusiveStartYear1",
                PGSInclusiveStartYear = "PGSInclusiveStartYear1",

                ESInclusiveEndYear = "ESInclusiveEndYear1",
                HSInclusiveEndYear = "HSInclusiveEndYear1",
                VSInclusiveEndYear = "VSInclusiveEndYear1",
                CSInclusiveEndYear = "CSInclusiveEndYear1",
                PGSInclusiveEndYear = "PGSInclusiveEndYear1",

                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now
            };

            EducationInfoList = new List<EducationInfo>()
            {
                new EducationInfo
                {
                    IDNo = 1,
                    EmployeeCode = "1",

                    ESName = "ESName1",
                    HSName = "HSName1",
                    VSName = "VSName1",
                    CSName = "CSName1",
                    PGSName = "PGSName1",

                    ESAddress = "ESAddress1",
                    HSAddress = "HSAddress1",
                    VSAddress = "VSName1",
                    CSAddress = "CSAddress1",
                    PGSAddress = "PGSAddress1",

                    VSCourse = "VSCourse1",
                    CSCourse = "CSCourse1",
                    PGSCourse = "PGSCourse1",

                    ESInclusiveStartYear = "ESInclusiveStartYear1",
                    HSInclusiveStartYear = "HSInclusiveStartYear1",
                    VSInclusiveStartYear = "VSInclusiveStartYear1",
                    CSInclusiveStartYear = "CSInclusiveStartYear1",
                    PGSInclusiveStartYear = "PGSInclusiveStartYear1",

                    ESInclusiveEndYear = "ESInclusiveEndYear1",
                    HSInclusiveEndYear = "HSInclusiveEndYear1",
                    VSInclusiveEndYear = "VSInclusiveEndYear1",
                    CSInclusiveEndYear = "CSInclusiveEndYear1",
                    PGSInclusiveEndYear = "PGSInclusiveEndYear1",

                    CreatedBy = "webadmin",
                    CreatedOn = DateTime.Now
                }
            };

            repoFEducationInfo.Setup(x => x.Get(EducationInfoId)).ReturnsAsync(EducationInfo);
            repoFEducationInfo.Setup(x => x.GetAll()).ReturnsAsync(EducationInfoList);
            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task EducationInfoController_GetById()
        {
            //arrange
            _EducationInfoController = new EducationInfoController(repoFEducationInfo.Object, repoContext.Object);
            ///act
            var getEducationInfo = await _EducationInfoController.Get(EducationInfoId);
            //assert
            Assert.AreEqual(EducationInfoId, getEducationInfo.IDNo);
        }

        [TestMethod]
        public async Task EducationInfoController_GetAll()
        {
            //arrange
            _EducationInfoController = new EducationInfoController(repoFEducationInfo.Object, repoContext.Object);
            ///act
            var getEducationInfoList = await _EducationInfoController.GetAll();
            //assert
            Assert.AreSame(EducationInfoList, getEducationInfoList);
        }
    }
}
