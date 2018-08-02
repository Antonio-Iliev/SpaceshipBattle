using SpaceshipBattle.Entities;
using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities.Weapons
{
    public class Weapon : Item, IWeapon
    {
        public Weapon(string model, int price, int weight) : base(model, price, weight)
        {

        }

        public int Power { get; set; } = 10;
        //steps 
        public int Speed { get; set; } = 2;

        public int ClipCapacity { get; set; }

        public IBullet Bullet { get; set; }
    }
}
