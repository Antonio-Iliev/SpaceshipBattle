using SpaceshipBattle.Contracts;

namespace SpaceshipBattle.Contracts.Entities
{
    public interface IProtectiveFields :IArmour
    {
        int Reflection { get; }
        int Refraction { get; }
    }
}
