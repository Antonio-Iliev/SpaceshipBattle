using System.Collections.Generic;

namespace SpaceshipBattle.Entities.Spaceships
{
    public interface ISpaceShipDesign
    {
        IEnumerable<string> DrossaRight { get; }
        IEnumerable<string> DrossLeft { get; }
        IEnumerable<string> FuturisticLeft { get; }
        IEnumerable<string> FuturisticRight { get; }
    }
}