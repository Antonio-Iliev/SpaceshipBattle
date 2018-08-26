using System.Collections.Generic;

namespace SpaceshipBattle.Core.Registration
{
    public interface ISelectingSpaceship
    {
        Dictionary<string, string> ChooseSpaceShip();
        Dictionary<string, string> ChooseComponent();
    }
}