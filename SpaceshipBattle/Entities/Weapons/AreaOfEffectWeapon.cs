using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Entities.Weapon;
using SpaceshipBattle.Entities.Weapons;
using System;

namespace SpaceshipBattle.Entities.Weapons
{
    public class AreaOfEffectWeapon : WeaponAbstract, IAreaOfEffectWeapon
    {
        protected int spashArea;

        public AreaOfEffectWeapon(string model, int price, int weight, int power, int speed, int clipCapacity, int splashArea) : base(model, price, weight, power, speed, clipCapacity)
        {
            SplashArea = splashArea;
            this.Damage = damage;
        }
        protected int damage;
        public int SplashArea { get; protected set; }
        public override int Damage { get; set; }


        public override int DealDamage(int shootingPlayerBulletPosition, int shotPlayerPosition)
        {
            if (shootingPlayerBulletPosition <= 0 || shotPlayerPosition <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid player or bullet position");
            }
            else
            {
                //Assign min/max positions of the ship
                var topSpaceShipPositoon = shotPlayerPosition - 2;
                var bottomSpaceShipPosition = shotPlayerPosition + 2;

                if (shootingPlayerBulletPosition >= topSpaceShipPositoon
                   && shootingPlayerBulletPosition <= bottomSpaceShipPosition)
                {
                    return damage = Power;
                }
                else if (shootingPlayerBulletPosition >= topSpaceShipPositoon - this.SplashArea
                    && shootingPlayerBulletPosition <= bottomSpaceShipPosition + this.SplashArea)
                {
                    return damage = Power / 2;
                }
                else
                {
                    return 0;
                }
            }

        }

    }
}
