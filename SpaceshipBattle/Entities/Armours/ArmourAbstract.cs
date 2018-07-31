using SpaceshipsBattle.Contracts;

namespace SpaceshipsBattle.Entities.Armour
{
    public abstract class ArmourAbstract : IArmour
    {
        public abstract string Model { get; }
        public abstract int Points { get; }
        public abstract int Price { get; }
        public abstract int Weight { get; }

    }
}
