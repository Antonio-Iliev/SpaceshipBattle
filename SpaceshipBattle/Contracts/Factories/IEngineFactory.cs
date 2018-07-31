using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Contracts.Factories
{
    public interface IEngineFactory
    {
        IEngine CreateEngine(string model);
    }
}
