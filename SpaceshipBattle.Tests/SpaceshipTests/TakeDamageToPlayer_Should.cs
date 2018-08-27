using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Core;
using SpaceshipBattle.Tests.SpaceshipTests.Mocks;
using System;


namespace SpaceshipBattle.Tests.SpaceshipTests
{
    [TestClass]
    public class TakeDamageToPlayer_Should
    {
        [TestMethod]
        public void ThrowNullReferenceException_WhenNullSpaceshipIsGiven()
        {
            //Arrange
            var engineMock = new Mock<ISpaceshipEngine>();
            var armourMock = new Mock<IArmour>();
            var weaponMock = new Mock<IWeapon>();

            var spaceship = new SpaceshipMock(engineMock.Object, armourMock.Object, weaponMock.Object, "model");

            Assert.ThrowsException<NullReferenceException>(() => spaceship.TakeDamageToPlayer(null, 10));
        }

        [TestMethod]
        public void DecreaseArmourCoefficient_WhenInvokedAndArmourCoefficientIsPositive()
        {
            //Arrange
            var engineMock = new Mock<ISpaceshipEngine>();
            var armourMock = new Mock<IArmour>();
            var weaponMock = new Mock<IWeapon>();

            armourMock.SetupAllProperties();

            var spaceship = new SpaceshipMock(engineMock.Object, armourMock.Object, weaponMock.Object, "spaceshipModel");

            var secondSpaceship = new SpaceshipMock(engineMock.Object, armourMock.Object, weaponMock.Object, "spaceshipModel");

            var armour = armourMock.Object;
            armour.ArmourCoefficient = 11;

            //Act
            int damage = 10;
            spaceship.TakeDamageToPlayer(secondSpaceship, damage);

            //Assert
            var expected = 1;
            var result = armour.ArmourCoefficient;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DecreaseHealth_WhenInvokedAndArmourCoefficientIsNotPositive()
        {
            //Arrange
            var engineMock = new Mock<ISpaceshipEngine>();
            var armourMock = new Mock<IArmour>();
            var weaponMock = new Mock<IWeapon>();

            armourMock.SetupAllProperties();

            var spaceship = new SpaceshipMock(engineMock.Object, armourMock.Object, weaponMock.Object, "spaceshipModel");

            var secondSpaceship = new SpaceshipMock(engineMock.Object, armourMock.Object, weaponMock.Object, "spaceshipModel");

            secondSpaceship.Health = 100;

            //Act
            int damage = 10;
            spaceship.TakeDamageToPlayer(secondSpaceship, damage);

            //Assert
            var expected = 90;
            var result = secondSpaceship.Health;
            Assert.AreEqual(expected, result);
        }
    }
}
