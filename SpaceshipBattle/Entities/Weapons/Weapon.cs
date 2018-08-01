using SpaceshipBattle.Entities;
using SpaceshipsBattle.Contracts;
using System;

namespace SpaceshipsBattle.Entities.Weapons
{
    public class Weapon : Item, IWeapon
    {
        protected int weight;
        protected int price;
        public Weapon(string model, int price, int weight, int power, int speed, int clipCapacity) : base(model, price, weight)
        {
            Power = power;
            Speed = speed;
            ClipCapacity = clipCapacity;

        }
        public int Power { get; }
        public int Speed { get; }
        public int ClipCapacity { get; }
        public int RemainingClips { get; private set; }

        public double Damage => this.Power + this.Speed / 5;


        public IBullet Bullet { get; }

    }
}
