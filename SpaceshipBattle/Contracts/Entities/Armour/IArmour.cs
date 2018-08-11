namespace SpaceshipBattle.Contracts
{
    public interface IArmour : IItem
    {
        int Points { get; }

        int ArmourCoefficient { get; set; } 

    }
}
