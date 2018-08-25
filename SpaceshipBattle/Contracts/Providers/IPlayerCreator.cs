using SpaceshipBattle.Contracts;

namespace SpaceshipBattle.Core
{
    public interface IPlayerCreator
    {
        IPlayer CreatePlayer(IRegistration playerParameters);
    }
}