using SpaceshipsBattle.Contracts;

namespace SpaceshipBattle.Contracts.Factories
{
    interface IWeaponFactory
    {
        IWeapon CreateEngine(string model);
    }
}
