namespace SpaceshipBattle.Contracts.Factories
{
    public interface IEngineFactory
    {
        ISpaceshipEngine CreateEngine(string model);
    }
}
