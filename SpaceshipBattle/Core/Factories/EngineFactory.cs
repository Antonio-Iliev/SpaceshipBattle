using SpaceshipBattle.Entities.Engines;
using SpaceshipsBattle.Contracts;
using SpaceshipsBattle.Contracts.Factories;
using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Core.Factories
{
    public class EngineFactory : IEngineFactory
    {
        public IEngine CreateEngine(string model)
        {
            switch (model)
            {
                case "TDI":
                    return new AutomobileEngine("1.9 TDI", 500, 250, 110, 80, FuelType.Diesel);
                case "V8":
                    return new AutomobileEngine("V8", 500, 250, 110, 80, FuelType.Diesel);

                default: throw new ArgumentException("There is no such a model!");                    
            }
        }


    }
}
