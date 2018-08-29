using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceshipBattle.Entities.Weapons;
using SpaceshipBattle.Tests.WeaponAbstractTest.Mock;
using System;

namespace SpaceshipBattle.Tests.WeaponTests.CriticalStrikeWeaponTests
{
    [TestClass]
    public class CreateCriticalStrikeWeapon_Should
    {

        [TestMethod]
        public void DealNormalDamage_WhenDirectHit()
        {
            //Arrange
            var engine = new CriticalStrikeWeapon("Laser", 2000, 22, 8, 4, 200, 0);

            //Assert
            Assert.AreEqual(engine.DealDamage(1, 1), 8);
        }

        [TestMethod]
        [DataRow(1,5)]        
        public void NotDealDamage_WhenNotHit(int value1, int value2)
        {
            //Arrange
            var engine = new CriticalStrikeWeapon("Laser", 2000, 22, 8, 4, 200, 0);

            //Assert
            Assert.AreEqual(engine.DealDamage(value1, value2), 0);
        }

        [TestMethod]
        [DataRow(1, 1)]
        public void DealCriticalDamage_WhenCriticalHit(int value1, int value2)
        {
            //Arrange
            var engine = new CriticalStrikeWeapon("Laser", 2000, 22, 8, 4, 200, 100);

            //Assert
            Assert.AreEqual(engine.DealDamage(value1, value2), 12);
        }

        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(1,0)]
        [DataRow(1, -1)]
        public void ThrowError_WhenParametersInvalid(int value1, int value2)
        {
            //Arrange
            var engine = new CriticalStrikeWeapon("Cannon", 2000, 22, 8, 4, 200, 2);

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.DealDamage(value1, value2));

        }
    }
}
