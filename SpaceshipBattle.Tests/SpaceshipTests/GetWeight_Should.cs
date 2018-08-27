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
    public class GetWeight_Should
    {
        [TestMethod]
        public void ReturnProperValue_WhenGetMethodIsCalled()
        {
            //Arrange
            var engineMock = new Mock<ISpaceshipEngine>();
            var armourMock = new Mock<IArmour>();
            var weaponMock = new Mock<IWeapon>();

            var spaceship = new SpaceshipMock(engineMock.Object, armourMock.Object, weaponMock.Object, "valid model");

            //Act
            var result = spaceship.Weight;

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}
