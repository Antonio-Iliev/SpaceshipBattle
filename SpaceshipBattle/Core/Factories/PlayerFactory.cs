using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Players;

namespace SpaceshipBattle.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string name, ISpaceShip spaceship)
        {
            return new Player(name, spaceship);
        }
    }
}
