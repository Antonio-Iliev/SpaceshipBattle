using SpaceshipBattle.Contracts.Factories;
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
                    return new Weapon("AK47",2000,20, 8, 1, 200);

                case "Cannon":

                    return new Weapon("Cannon",3000,30, 12, 3, 50);
                case "Laser":

                    return new Weapon("Laser",2500,20, 10, 2, 100);
                case "Plasma Weapon":
                    return new Weapon("Plasma Weapon",4000,40, 15, 4, 40);
                default: throw new ArgumentException("Please select valid weapon!");
            }
        }
    }
}
