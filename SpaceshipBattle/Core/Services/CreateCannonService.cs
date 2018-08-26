using SpaceshipBattle.Contracts;
using SpaceshipBattle.Core.Services;
using SpaceshipBattle.Entities.Weapons;

namespace SpaceshipBattle.Core.Services
{
    public class CreateCannonService : IService
    {
        private const string weaponModel = "Cannon";
        private const int price = 3000;
        private const int weight = 30;
        private const int power = 12;
        private const int speed = 4;
        private const int clipCapacity = 50;
        private const int splashArea = 1;

        public IWeapon CreateWeapon()
        {
            return new AreaOfEffectWeapon(weaponModel, price, weight, power, speed, clipCapacity, splashArea);
        }
    }
}
