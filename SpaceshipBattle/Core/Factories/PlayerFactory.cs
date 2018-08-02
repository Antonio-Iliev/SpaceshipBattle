using SpaceshipBattle.Contracts.Factories;
using SpaceshipsBattle.Contracts;
using SpaceshipsBattle.Entities.Players;
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
