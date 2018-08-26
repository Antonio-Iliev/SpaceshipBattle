using SpaceshipBattle.Contracts;
using SpaceshipBattle.Core.Services;
using SpaceshipBattle.Entities.Weapons;

namespace SpaceshipBattle.Core.Services
{
    public class CreatePlasmaWeaponService : IService
    {
        private const string weaponModel = "Plasma Weapon";
        private const int price = 4000;
        private const int weight = 40;
        private const int power = 15;
        private const int speed = 2;
        private const int clipCapacity = 40;
        private const int splashArea = 2;

        public IWeapon CreateWeapon()
        {
            return new AreaOfEffectWeapon(weaponModel, price, weight, power, speed, clipCapacity, splashArea);
        }
    }
}
