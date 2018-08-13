using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts
{
   public interface IGameController
    {
        void Play(IPlayer firstPlayer, IPlayer secondPlayer);
    }
}
