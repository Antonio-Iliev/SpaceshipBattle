using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Entities;
using SpaceshipBattle.Contracts;

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
