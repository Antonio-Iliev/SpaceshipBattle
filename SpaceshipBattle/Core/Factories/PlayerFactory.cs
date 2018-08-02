using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string name, ISpaceship spaceship)
        {
            return new Player(name, spaceship);
        }
    }
}
