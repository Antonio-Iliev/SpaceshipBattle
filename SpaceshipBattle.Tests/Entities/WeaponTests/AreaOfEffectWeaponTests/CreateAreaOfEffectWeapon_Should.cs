using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceshipBattle.Contracts.Entities.Weapon;
using SpaceshipBattle.Entities.Weapons;
using SpaceshipBattle.Tests.WeaponAbstractTest.Mock;
using System;
namespace SpaceshipBattle.Tests.WeaponTests.AreaOfEffectWeaponTests
{
    [TestClass]
    public class CreateAreaOfEffectWeapon_Should
    {
        [TestMethod]
        public void DealProperDamage_WhenDirectHit()
        {
            //Arrange
            var engine = new AreaOfEffectWeapon("Cannon", 2000, 22, 8, 4, 200, 30);

            //Assert
            Assert.AreEqual(engine.DealDamage(1, 1), 8);
        }
        [TestMethod]
        public void DealProperDamage_WhenCloseHit()
        {
            //Arrange
            var engine = new AreaOfEffectWeapon("Cannon", 2000, 22, 8, 4, 200, 2);

            //Assert
            Assert.AreEqual(engine.DealDamage(1, 4), 4);
        }

        [TestMethod]
        public void NotDealDamage_WhenNotHit()
        {
            //Arrange
            var engine = new AreaOfEffectWeapon("Cannon", 2000, 22, 8, 4, 200, 2);

            //Assert
            Assert.AreEqual(engine.DealDamage(1, 6), 0);
        }

        [TestMethod]
        public void ThrowError_WhenParametersInvalid()
        {
            //Arrange
            var engine = new AreaOfEffectWeapon("Cannon", 2000, 22, 8, 4, 200, 2);

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.DealDamage(2, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.DealDamage(0, 2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.DealDamage(0, -1));

        }

    }
}
