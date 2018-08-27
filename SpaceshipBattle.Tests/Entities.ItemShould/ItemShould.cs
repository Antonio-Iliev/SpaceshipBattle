using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceshipBattle.Tests.Entities.ItemShould.Mock;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.Entities.ItemShould
{
    [TestClass]
    public class ItemShould
    {
        private string validModel = "Valid Model";
        private int validPrice = 2500;
        private int validWeight = 500;


        [TestMethod]
        public void Item_WhenPassValueToModel_ShouldAssignCorrectValue()
        {
            //Arrange & Act
            var item = new ItemMock(validModel, validPrice, validWeight);

            //Assert
            Assert.AreEqual(item.Model, validModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Item_WhenPassNullToModel_ShouldThrowArgumentNullException()
        {
            //Arrange & Act & Assert
            var item = new ItemMock(null, validPrice, validWeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Item_WhenPassEmptyValueToModel_ShouldThrowArgumentNullException()
        {
            //Arrange & Act & Assert
            var item = new ItemMock("", validPrice, validWeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("a")]
        [DataRow("long long long long very long and long and long long long model name")]
        public void Item_WhenPassOutOfRangeValueToModel_ShouldThrowArgumentOutOfRangeException(string model)
        {
            //Arrange & Act & Assert
            var item = new ItemMock(model, validPrice, validWeight);
        }

        [TestMethod]
        public void Item_WhenPassValueToPrice_ShouldAssignCorrectValue()
        {
            //Arrange & Act
            var item = new ItemMock(validModel, validPrice, validWeight);

            //Assert
            Assert.AreEqual(item.Price, validPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(999)]
        [DataRow(50001)]
        public void Item_WhenPassOutOfRangeValueToPrice_ShouldThrowArgumentOutOfRangeException(int price)
        {
            //Arrange & Act & Assert
            var item = new ItemMock(validModel, price, validWeight);
        }

        [TestMethod]
        public void Item_WhenPassValueToWeight_ShouldAssignCorrectValue()
        {
            //Arrange & Act
            var item = new ItemMock(validModel, validPrice, validWeight);

            //Assert
            Assert.AreEqual(item.Weight, validWeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(-1)]
        [DataRow(1001)]
        public void Item_WhenPassOutOfRangeValueToWeight_ShouldThrowArgumentOutOfRangeException(int weight)
        {
            //Arrange & Act & Assert
            var item = new ItemMock(validModel, validPrice, weight);
        }
    }
}
