using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities
{
    public struct Bullet : IBullet
    {
        public int PositionX { get; set; }

        public int PositionY { get; set; }
    }
}
