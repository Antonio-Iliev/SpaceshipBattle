using SpaceshipBattle.Entities;
using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities.Weapons
{
    public abstract class Weapon : Item, IWeapon
    {
        public int Power { get; set; }
        //steps 
        public int Speed { get; set; }

        public int ClipCapacity { get; set; }

        public IBullet Bullet { get; set; }
    }
}
