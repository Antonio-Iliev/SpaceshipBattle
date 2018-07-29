using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Contracts
{
    public interface IEngine : IItem
    {
        int Power { get; }
        int FuelCapacity { get; }
        FuelType FuelType { get; }
    }
}
