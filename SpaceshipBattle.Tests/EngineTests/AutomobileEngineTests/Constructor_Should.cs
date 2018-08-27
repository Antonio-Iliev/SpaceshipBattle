using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceshipBattle.Entities.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.EngineTests.AutomobileEngineTests
{
    [TestClass]
    class Constructor_Should
    {
        [TestMethod]
        public void SetProperModel_WhenTheObjectIsConstructed()
        {
            // Arrange &§ Act
            var engine = new AutomobileEngine("Valid model", 2000, 200, 200, FuelType.Diesel, 200, 2000, 4);

            // Assert
            Assert.AreEqual("Valid model", engine.Model);
        }

    }
}
