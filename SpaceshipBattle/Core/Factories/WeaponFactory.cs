using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Entities.Weapons;
using SpaceshipsBattle.Contracts;
using SpaceshipsBattle.Entities.Weapons;
using System;

namespace SpaceshipBattle.Core.Factories
{
    class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string model)
        {
            switch (model)
            {
                case "AK47": 
                    return new CriticalStrikeWeapon("AK47", 2000, 20, 8, 1, 200, 30);

                case "Cannon":

                    return new AreaOfEffectWeapon("Cannon", 3000, 30, 12, 3, 50, 1);
                case "Laser":

                    return new CriticalStrikeWeapon("Laser", 2500, 20, 10, 2, 100, 25);
                case "Plasma Weapon":
                    return new AreaOfEffectWeapon("Plasma Weapon", 4000, 40, 15, 4, 40, 2);
                default: throw new ArgumentException("Please select valid weapon!");
            }
        }
    }
}
