using SpaceshipBattle.Contracts;

namespace SpaceshipBattle.Core.Services.EngineServices
{
    public interface IEngineService
    {
        ISpaceshipEngine CreateEngine();
    }
}
