

namespace SpaceshipBattle.Contracts
{
    public interface IWeapon : IItem
    {
        int Power { get; }

        int Speed { get; }

        int ClipCapacity { get; }

        //TODO
        IBullet Bullet { get; set; }

        int DealDamage( IPlayer firstPlayer, IPlayer secondPlayer);
    }
}
