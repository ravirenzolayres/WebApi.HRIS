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
    public class PositionTests
    {
        private Mock<IFPosition> repoFPosition = new Mock<IFPosition>();
        private Mock<IDPosition> repoDPosition = new Mock<IDPosition>();

        private Mock<IHttpContextAccessor> repoContext = new Mock<IHttpContextAccessor>();

        private PositionController _PositionController;
        private FPosition _fPosition;

        private int PositionId;
        private string PositionCode;
        private Position Position;
        private List<Position> PositionList;

        [TestInitialize]
        public void Setup()
        {
            PositionId = 3;
            PositionCode = "P003";

            Position = new Position
            {
                IDNo = 3,
                PositionCode = "P003",
                PositionName = "Position3",
                CreatedBy = "webadmin",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            PositionList = new List<Position>()
            {
                new Position { IDNo = 1, PositionCode = "P004",PositionName = "Position4", IsActive = true,CreatedBy = "webadmin",CreatedOn = DateTime.Now },
                new Position { IDNo = 2, PositionCode = "P005",PositionName = "Position5", IsActive = false, CreatedBy = "webadmin",CreatedOn = DateTime.Now},
                new Position { IDNo = 3, PositionCode = "P006",PositionName = "Position6", IsActive = true ,CreatedBy = "webadmin",CreatedOn = DateTime.Now}
            };

            repoFPosition.Setup(x => x.Get(PositionId)).ReturnsAsync(Position);
            repoFPosition.Setup(x => x.GetAll()).ReturnsAsync(PositionList);

            repoDPosition.Setup(x => x.Get(It.IsAny<Func<Position,bool>>())).ReturnsAsync(Position);
            repoDPosition.Setup(x => x.GetAll(It.IsAny<Func<Position,bool>>())).ReturnsAsync(PositionList);

            repoContext.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
        }

        [TestMethod]
        public async Task PositionController_GetById()
        {
            //arrange
            _PositionController = new PositionController(repoFPosition.Object, repoContext.Object);
            ///act
            var getPosition = await _PositionController.Get(PositionId);
            //assert
            Assert.AreEqual(PositionId, getPosition.IDNo);
        }

        [TestMethod]
        public async Task PositionController_GetAll()
        {
            //arrange
            _PositionController = new PositionController(repoFPosition.Object, repoContext.Object);
            ///act
            var getPositionList = await _PositionController.GetAll();
            //assert
            Assert.AreSame(PositionList, getPositionList);
        }


        [TestMethod]
        public async Task FPosition_GetCode()
        {
            //arrange
            _fPosition = new FPosition(repoDPosition.Object);
            ///act
            var getPositionId = await _fPosition.GetCode(PositionCode);
            //assert
            Assert.AreEqual(PositionId, getPositionId);
        }
    }
}
