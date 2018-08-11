using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts.Entities.Engines
{
    public interface IHighTechEngine : ISpaceshipEngine
    {
        int Thrust { get; }
    }
}
