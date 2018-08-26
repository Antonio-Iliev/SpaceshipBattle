using SpaceshipBattle.Contracts;
using System.Windows.Input;

namespace SpaceshipBattle.Contracts.Factories
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string model);
    }
}
