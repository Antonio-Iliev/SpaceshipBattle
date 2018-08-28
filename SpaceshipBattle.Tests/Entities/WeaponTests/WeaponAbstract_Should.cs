using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceshipBattle.Tests.WeaponAbstractTest.Mock;

namespace SpaceshipBattle.Tests.WeaponTests
{
    [TestClass]
    public class WeaponAbstract_Should
    {
        [TestMethod]
        [DataRow(11)]
        [DataRow(110)]
        [DataRow(240)]
        public void ReturnCorrectValue_WhenPowerIsSet(int value)
        {
            //Arrange
            var weapon = new WeaponAbstractMock("AK47", 1300, 222, value, 800, 100);

            //Act & Assert
            Assert.AreEqual(weapon.Power, value);
        }
    }
}
