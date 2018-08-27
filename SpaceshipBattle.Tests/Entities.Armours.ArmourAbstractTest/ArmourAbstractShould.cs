using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipBattle.Tests.Entities.Armours.ArmourAbstractTest.Mock;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.Entities.Armours.ArmourAbstractTest
{
    [TestClass]
    public class ArmourAbstractShould
    {
        [TestMethod]
        [DataRow(11)]
        [DataRow(110)]
        [DataRow(240)]
        public void Points_WhenSetValue_ShouldReturnCorrectValue(int actual)
        {
            //Arrange
            var armour = new ArmourAbstractMock("Model", 4000, 500, actual, ArmourType.Aerogel);

            //Act & Assert
            Assert.AreEqual(armour.Points, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(9)]
        [DataRow(251)]
        public void Points_WhenValueIsOutOfRange_ShouldThrowArgumentOutOfRangeException(int points)
        {
            //Arrange & Act & Assert
            var armour = new ArmourAbstractMock("Model", 4000, 500, points, ArmourType.Aerogel);
        }

        [TestMethod]
        [DataRow("Defense points")]
        [DataRow("Armour type")]
        public void Points_WhenToStringIsCalled_ShouldReturnMessage(string acutal)
        {
            //Arrange
            var armour = new ArmourAbstractMock("Model", 4000, 500, 60, ArmourType.Aerogel);

            //Act
            var result = armour.ToString();

            //Assert
            StringAssert.Contains(result, acutal);
        }
    }
}
