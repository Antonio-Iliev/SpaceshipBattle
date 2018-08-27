using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Tests.SpaceshipTests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.SpaceshipTests
{
    [TestClass]
    public class GetModel_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenGetMethodIsCalled()
        {
            //Arrange
            var engineMock = new Mock<ISpaceshipEngine>();
            var armourMock = new Mock<IArmour>();
            var weaponMock = new Mock<IWeapon>();

            var spaceship = new SpaceshipMock(engineMock.Object, armourMock.Object, weaponMock.Object, "valid model");

            //Act
            var result = spaceship.Model;

            //Assert
            Assert.AreEqual("valid model", result);
        }
    }
}
