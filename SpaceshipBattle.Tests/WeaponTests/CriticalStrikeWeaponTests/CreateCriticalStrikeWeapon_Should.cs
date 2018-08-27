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
        public void CreateCriticalStrikeWeapon_WhenMethodIsCalled()
        {
            //Arrange
            var engine = new CriticalStrikeWeapon("AK47", 2000, 20, 8, 4, 200, 30);

            //Assert
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(1300)]
        public void ThrowError_WhenWeightIsOutOfRange(int value)
        {
            //Arrange
            var weapon = new CriticalStrikeWeapon("AK47", 1300, value, 22, 800, 22, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowError_WhenNullValueIsPassed()
        {
            //Arrange
            var weapon = new CriticalStrikeWeapon(null, 1300, 34, 22, 800, 22, 100);
        }

        [TestMethod]
        public void ReturnProperMessage_WhenToStringIsCalled()
        {
            //Arrange
            var engine = new CriticalStrikeWeapon("AK47", 1300, 55, 22, 800, 22, 100);

            //Act
            var result = engine.ToString();

            //Assert
            StringAssert.Contains(result, "Model: AK47"
                + Environment.NewLine + "Price: 1300$"
                + Environment.NewLine + "Weight: 55kg");
        }
    }
}
