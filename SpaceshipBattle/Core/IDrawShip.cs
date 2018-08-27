using SpaceshipBattle.Contracts;

namespace SpaceshipBattle.Core
{
    public interface IDrawShip
    {
        string DrawShipPlayerOne(IPlayer player);
        string DrawShipPlayerTwo(IPlayer player);
    }
}