using SpaceshipBattle.Contracts;

namespace SpaceshipBattle.Contracts.Entities
{
    public interface IDenseArmour : IArmour
    {
        int Hardness { get; }
        int Toughness { get; }
    }
}
