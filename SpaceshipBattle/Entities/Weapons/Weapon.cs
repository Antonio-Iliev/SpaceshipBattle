using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities.Weapons
{
    public abstract class Weapon : IWeapon
    {
        // lazer, ak47, bazuka, 
        public string  Model { get; set; }

        public int Power { get; set; }
        //steps 
        public int Speed { get; set; }

        public int Price { get; set; }

        public int  Weight { get; set; }

        public int ClipCapacity { get; set; }

        public IBullet Bullet { get; set; }
    }
}
