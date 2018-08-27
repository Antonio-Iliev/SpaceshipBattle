using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceshipBattle.Entities.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.EngineTests.AutomobileEngineTests
{
    [TestClass]
    public class ToString_Should
    {
        [TestMethod]
        public void ContainsCapacity_WhenToStringIsCalled()
        {
            //Arrange
            var engine = new AutomobileEngine("engine", 2000,200,200, FuelType.Diesel, 200, 2000, 4);
            
            //Act
            var result = engine.ToString();

            //Assert
            StringAssert.Contains(result, "Capacity: 2000cc");
            
        }
    }

}
