using SpaceshipBattle.Entities;
using SpaceshipBattle.Contracts;
using System;

namespace SpaceshipBattle.Entities.Weapons
{
    public abstract class WeaponAbstract : Item, IWeapon
    {
        protected int weight;
        protected int price;
        public WeaponAbstract(string model, int price, int weight, int power, int speed, int clipCapacity) : base(model, price, weight)
        {
            Power = power;
            Speed = speed;
            ClipCapacity = clipCapacity;
        }

        public int Power { get; }
        public int Speed { get; }
        public int ClipCapacity { get; }
        public int RemainingClips { get; private set; }               

        public IBullet Bullet { get; set; }      
                
    }
}
