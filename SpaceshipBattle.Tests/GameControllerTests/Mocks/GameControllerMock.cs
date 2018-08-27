using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.GameControllerTests.Mocks
{
    internal sealed class GameControllerMock : GameController
    {
        public GameControllerMock(IWriter writer, IReader reader, IApplicationInterface appInterface) : base(writer, reader, appInterface)
        {
        }

        public void ExposedMoveDown(IPlayer player)
        {
             base.TryMoveDown(player);
        }

        public void ExposedMoveUp(IPlayer player)
        {
            base.TryMoveUp(player);
        }

        public void ExposedPrepareToShoot(IPlayer player)
        {
            base.PrepareToShoot(player);
        }

    }
}
