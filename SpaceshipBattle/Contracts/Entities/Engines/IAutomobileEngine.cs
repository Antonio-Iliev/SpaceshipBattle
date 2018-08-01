using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts.Entities.Engines
{
    public interface IAutomobileEngine : IEngine
    {
        int Torque { get; }

        int Capacity { get; }

        int CylinderCount { get; }
    }
}
