namespace SpaceshipsBattle.Contracts.Factories
{
    public interface IEngineFactory
    {
        IEngine CreateEngine(string model);
    }
}
