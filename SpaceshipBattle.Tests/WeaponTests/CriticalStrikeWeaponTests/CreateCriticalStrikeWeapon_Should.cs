using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceshipBattle.Contracts.Entities.Weapon;
using SpaceshipBattle.Entities.Weapons;
using SpaceshipBattle.Tests.WeaponAbstractTest.Mock;
using System;

namespace SpaceshipBattle.Tests.WeaponTests.CriticalStrikeWeaponTests
{
    [TestClass]
    public class CreateCriticalStrikeWeapon_Should
    {
        [TestMethod]
        public void CreateCriticalStrikeWeapon_WhenMethodIsCalled()
        {
            //Arrange
            var engine = new CriticalStrikeWeapon("AK47", 2000, 20, 8, 4, 200, 30);
            
            //Assert
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        [DataRow(11)]
        [DataRow(110)]
        [DataRow(240)]
        public void ReturnCorrectValue_WhenPowerIsSet(int value)
        {
            //Arrange
            var weapon = new WeaponAbstractMock("AK47", 1300, 222, value,800 ,100);

            //Act & Assert
            Assert.AreEqual(weapon.Power, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(1300)]
        public void ThrowError_WhenWeightIsOutOfRange(int value)
        {
            //Arrange
            var weapon = new WeaponAbstractMock("AK47", 1300, value,22 , 800, 100);
        }
    }
}
