using SpaceshipBattle.Entities.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts
{
    public interface IEngine : IItem
    {
        int Power { get; }

        FuelType FuelType { get; }

        double EngineEfficiencyCoef { get; }
    }
}
