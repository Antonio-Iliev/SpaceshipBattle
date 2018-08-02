using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts.Factories
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string name, ISpaceship spaceship);
    }
}
