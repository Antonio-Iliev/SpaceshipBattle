using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Core;
using SpaceshipBattle.Entities.Spaceships;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.Core
{
    [TestClass]
    public class DrawShipShould
    {
        [TestMethod]
        public void DrawShipShould_WhenConstructorIsCall_ShouldReturnInstance()
        {
            //Arrange
            var spaceShipDesignMock = new Mock<ISpaceShipDesign>();

            //Act
            var result = new DrawShip(spaceShipDesignMock.Object);

            //Assert
            Assert.IsInstanceOfType(result, typeof(DrawShip));
        }

        [TestMethod]
        public void DrawShipPlayerOne_WhenCheckPlayerDesign_ShouldAssignRightShipDesign()
        {
            //Arrange
            var spaceShipDesignMock = new Mock<ISpaceShipDesign>();
            spaceShipDesignMock.SetupGet(x => x.DrossLeft).Returns(new string[] { "Dross-Mashup Spaceship" });
            spaceShipDesignMock.SetupGet(x => x.FuturisticLeft).Returns(new string[] { "Futuristic Spaceship" });

            var playerMock = new Mock<IPlayer>();
            playerMock.SetupGet(x => x.Spaceship.Model).Returns("Dross-Mashup Spaceship");

            var draw = new DrawShip(spaceShipDesignMock.Object);

            //Act
            draw.DrawShipPlayerOne(playerMock.Object);

            //Assert
            spaceShipDesignMock.Verify(x => x.DrossLeft, Times.Once);
        }

        [TestMethod]
        [DataRow("Dross-Mashup Spaceship")]
        [DataRow("Futuristic Spaceship")]
        [DataRow("New Model Spaceship")]
        public void DrawShipPlayerOne_WhenFinishDrawing_ShouldReturnMessage(string actual)
        {
            //Arrange
            var spaceShipDesignMock = new Mock<ISpaceShipDesign>();

            var playerMock = new Mock<IPlayer>();
            playerMock.SetupGet(x => x.Spaceship.Model).Returns(actual);

            var draw = new DrawShip(spaceShipDesignMock.Object);

            //Act
            var result = draw.DrawShipPlayerOne(playerMock.Object);

            //Assert
            StringAssert.Contains(result, actual);
        }

        [TestMethod]
        public void DrawShipPlayerTwo_WhenCheckPlayerDesign_ShouldAssignRightShipDesign()
        {
            //Arrange
            var spaceShipDesignMock = new Mock<ISpaceShipDesign>();
            spaceShipDesignMock.SetupGet(x => x.DrossaRight).Returns(new string[] { "Dross-Mashup Spaceship" });
            spaceShipDesignMock.SetupGet(x => x.FuturisticRight).Returns(new string[] { "Futuristic Spaceship" });

            var playerMock = new Mock<IPlayer>();
            playerMock.SetupGet(x => x.Spaceship.Model).Returns("Dross-Mashup Spaceship");

            var draw = new DrawShip(spaceShipDesignMock.Object);

            //Act
            draw.DrawShipPlayerTwo(playerMock.Object);

            //Assert
            spaceShipDesignMock.Verify(x => x.DrossaRight, Times.Once);
        }

        [TestMethod]
        [DataRow("Dross-Mashup Spaceship")]
        [DataRow("Futuristic Spaceship")]
        [DataRow("New Model Spaceship")]
        public void DrawShipPlayerTwo_WhenFinishDrawing_ShouldReturnMessage(string actual)
        {
            //Arrange
            var spaceShipDesignMock = new Mock<ISpaceShipDesign>();

            var playerMock = new Mock<IPlayer>();
            playerMock.SetupGet(x => x.Spaceship.Model).Returns(actual);

            var draw = new DrawShip(spaceShipDesignMock.Object);

            //Act
            var result = draw.DrawShipPlayerTwo(playerMock.Object);

            //Assert
            StringAssert.Contains(result, actual);
        }
    }
}
