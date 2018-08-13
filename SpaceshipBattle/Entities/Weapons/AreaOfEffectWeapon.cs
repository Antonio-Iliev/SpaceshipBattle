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


        public override int DealDamage(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            if (firstPlayer.Spaceship.Weapon.Bullet.PositionY >= secondPlayer.Spaceship.PositionY - 2 && firstPlayer.Spaceship.Weapon.Bullet.PositionY <= secondPlayer.Spaceship.PositionY + 2)
            {
                return damage = Power;
            }
            else if (firstPlayer.Spaceship.Weapon.Bullet.PositionY >= secondPlayer.Spaceship.PositionY - (this.SplashArea + 2) && firstPlayer.Spaceship.Weapon.Bullet.PositionY <= secondPlayer.Spaceship.PositionY + this.SplashArea + 2)
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
