using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core;
using SpaceshipBattle.Tests.GameControllerTests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.GameControllerTests
{
   public class MoveDown_Should 
    {
        [TestMethod]
        public void ThrowNullReferenceException_WhenNullSpaceshipIsGiven()
        {
            //Arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var appInt = new Mock<IApplicationInterface>();

            //var gc = new GameControllerMock(writerMock.Object, readerMock.Object, appInt.Object);

            
        }
    }
}
