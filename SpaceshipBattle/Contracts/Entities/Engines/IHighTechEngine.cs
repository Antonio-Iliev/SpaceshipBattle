using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts.Entities.Engines
{
    public interface IHighTechEngine : IEngine
    {
        int Thrust { get; }
    }
}
