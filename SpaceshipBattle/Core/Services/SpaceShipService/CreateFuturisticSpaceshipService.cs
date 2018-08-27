using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Spaceships;

namespace SpaceshipBattle.Core.Services.SpaceShipService
{
    public class CreateFuturisticSpaceshipService : ISpaceShipService
    {
        public ISpaceShip CreateSpaceship(string model, ISpaceshipEngine engine, IArmour armour, IWeapon weapon)
        {
            return new FuturisticSpaceship(engine, armour, weapon, model);
        }
    }
}
