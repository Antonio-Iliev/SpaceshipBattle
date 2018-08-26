using SpaceshipBattle.Contracts;
using SpaceshipBattle.Core.Services;
using SpaceshipBattle.Entities.Weapons;

namespace SpaceshipBattle.Core.Services
{
    public class CreateLaserService : IService
    {
        private const string weaponModel = "Laser";
        private const int price = 2500;
        private const int weight = 20;
        private const int power = 10;
        private const int speed = 3;
        private const int clipCapacity = 100;
        private const int criticalStrikeChance = 25;

        public IWeapon CreateWeapon()
        {
            return new CriticalStrikeWeapon(weaponModel, price, weight, power, speed, clipCapacity, criticalStrikeChance);
        }
    }
}
