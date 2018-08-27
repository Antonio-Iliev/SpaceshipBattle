using SpaceshipBattle.Contracts;

namespace SpaceshipBattle.Core.Services.SpaceShipService
{
    public interface ISpaceShipService
    {
        ISpaceShip CreateSpaceship(string model, ISpaceshipEngine engine, IArmour armour, IWeapon weapon);
    }
}
