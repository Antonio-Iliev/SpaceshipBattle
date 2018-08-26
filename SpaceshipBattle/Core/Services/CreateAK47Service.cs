using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Weapons;

namespace SpaceshipBattle.Core.Services
{
    public class CreateAK47Service : IService
    {
        private const string weaponModel = "AK470";
        private const int price = 2000;
        private const int weight = 20;
        private const int power = 8;
        private const int speed = 4;
        private const int clipCapacity = 200;
        private const int criticalStrikeChance = 30;

        public IWeapon CreateWeapon()
        {
            return new CriticalStrikeWeapon(weaponModel, price, weight, power, speed, clipCapacity, criticalStrikeChance);
        }
    }
}
