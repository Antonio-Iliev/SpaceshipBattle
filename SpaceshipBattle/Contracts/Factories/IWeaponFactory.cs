using SpaceshipBattle.Contracts;

namespace SpaceshipBattle.Contracts.Factories
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string model);
    }
}
