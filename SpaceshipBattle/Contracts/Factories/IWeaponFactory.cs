using SpaceshipBattle.Contracts;

namespace SpaceshipBattle.Contracts.Factories
{
    interface IWeaponFactory
    {
        IWeapon CreateWeapon(string model);
    }
}
