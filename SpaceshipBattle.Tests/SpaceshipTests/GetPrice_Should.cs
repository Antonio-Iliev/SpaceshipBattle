using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpaceshipBattle.Contracts;

namespace SpaceshipBattle.Tests.SpaceshipTests.Mocks
{
    [TestClass]
    public class GetPrice_Should
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
            var result = spaceship.Price;

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}
