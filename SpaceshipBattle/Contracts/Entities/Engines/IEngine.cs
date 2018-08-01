using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Contracts
{
    public interface IEngine : IItem
    {
        int Power { get; }

        FuelType FuelType { get; }

        int EngineCoefEfficiency { get; }
    }
}
