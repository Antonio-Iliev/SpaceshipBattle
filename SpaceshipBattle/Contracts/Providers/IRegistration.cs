using SpaceshipBattle.Contracts.Providers;
using System.Collections.Generic;

namespace SpaceshipBattle.Core
{
    public interface IRegistration
    {
        IReader Reader { get; set; }
        IWriter Writer { get; set; }
        Dictionary<string, string> ParametersForPlayer { get; }
        void ChooseName();
        void ChooseSpaceShip();
        void ChooseComponent();
    }
}