using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Entities.Weapon;
using SpaceshipBattle.Entities.Weapons;
using System;

namespace SpaceshipBattle.Entities.Weapons
{
    class CriticalStrikeWeapon : WeaponAbstract, ICriticalStrikeWeapon
    {

        public CriticalStrikeWeapon(string model, int price, int weight, int power, int speed, int clipCapacity, int criticalStrikeChance) : base(model, price, weight, power, speed, clipCapacity)
        {
            CriticalStrikeChance = criticalStrikeChance;
            this.Damage = damage;
        }
        protected int damage;
        public override int Damage { get; set; }
        public int CriticalStrikeChance
        { get; protected set; }

        public override int DealDamage(int shootingPlayerBulletPosition, int shotPlayerPosition)
        {
            //Assign min/max positions of the ship
            var topSpaceShipPositoon = shotPlayerPosition - 2;
            var bottomSpaceShipPosition = shotPlayerPosition + 2;

            if (shootingPlayerBulletPosition >= topSpaceShipPositoon && shootingPlayerBulletPosition <= bottomSpaceShipPosition)
            {
                Random gen = new Random();
                return damage = gen.Next(100) <= this.CriticalStrikeChance ? this.Power + (this.Power / 2) : this.Power;
            }
            else
            {
                return 0;
            }

        }

    }

}
