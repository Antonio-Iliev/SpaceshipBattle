using SpaceshipsBattle.Contracts;

namespace SpaceshipBattle.Contracts.Factories
{
    public interface IArmourFactory
    {
        IArmour CreateArmour(string model);
    }
}
