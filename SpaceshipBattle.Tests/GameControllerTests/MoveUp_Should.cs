using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.GameControllerTests.Mocks

{   [TestClass]
    public class MoveUp_Should
    {
        [TestMethod]
        public void ThrowNullReferenceException_WhenNullSpaceshipIsGiven()
        {
            //Arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var appInt = new Mock<IApplicationInterface>();

            var gc = new GameControllerMock(writerMock.Object, readerMock.Object, appInt.Object);

            var playerMock = new Mock<IPlayer>();

            // Act && Assert
            Assert.ThrowsException<NullReferenceException>(() => gc.ExposedMoveUp(null));
        }

        [TestMethod]
        public void DecreasePlayerPositionY_WhenValidParameterIsPassed()
        {
            //Arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var appInt = new Mock<IApplicationInterface>();

            appInt.SetupGet(a => a.WindowHeight).Returns(35);

            var gc = new GameControllerMock(writerMock.Object, readerMock.Object, appInt.Object);

            var playerMock = new Mock<IPlayer>();
            var spaceshipMock = new Mock<ISpaceship>();
            
            var spaceship = spaceshipMock.Object;
            
            playerMock.SetupGet(p => p.Spaceship).Returns(spaceship);
            spaceshipMock.SetupAllProperties();

            spaceshipMock.SetupGet(s => s.Speed).Returns(1);
             
            spaceship.PositionY = 5;

            // Act
            gc.ExposedMoveUp(playerMock.Object);

            //Assert
            var expected = 4;
            var result = spaceship.PositionY;
            Assert.AreEqual(expected, result);
        }
    }
}
