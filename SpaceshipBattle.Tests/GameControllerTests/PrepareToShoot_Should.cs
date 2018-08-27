using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core;
using SpaceshipBattle.Tests.GameControllerTests.Mocks;

namespace SpaceshipBattle.Tests.GameControllerTests
{
    [TestClass]
    public class PrepareToShoot_Should
    {
        [TestMethod]
        public void SetIsAtShootingTrue_WhenValidParameterIsPassed()
        {
            //Arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var appInt = new Mock<IApplicationInterface>();
                        
            var gc = new GameControllerMock(writerMock.Object, readerMock.Object, appInt.Object);

            var playerMock = new Mock<IPlayer>();
            var spaceshipMock = new Mock<ISpaceship>();

            var spaceship = spaceshipMock.Object;

            playerMock.SetupGet(p => p.Spaceship).Returns(spaceship);
            spaceshipMock.SetupAllProperties();

            var weaponMock = new Mock<IWeapon>();
            var bulletMock = new Mock<IBullet>();

            spaceshipMock.SetupGet(s => s.Weapon).Returns(weaponMock.Object);
            weaponMock.SetupGet(w => w.Bullet).Returns(bulletMock.Object);

            spaceship.IsAtShooting = false;

            //Act
            gc.ExposedPrepareToShoot(playerMock.Object);

            //Assert
            Assert.IsTrue(spaceship.IsAtShooting);
        }
    }
}
