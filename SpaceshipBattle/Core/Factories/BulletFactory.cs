using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Entities;
using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core.Factories
{
    public class BulletFactory : IBulletFactory
    {
        public IBullet CreateBullet()
        {
            return new Bullet();
        }
    }
}
