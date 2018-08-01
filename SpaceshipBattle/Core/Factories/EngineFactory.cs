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
                case "Trabant":
                    return new AutomobileEngine("Trabant Motor", 1000, 110, 26, FuelType.Petrol, 55, 594, 2); 
                    // 26 + 55 + 59 + 20 = 161 step 1
                case "TDI":
                    return new AutomobileEngine("VW 1.9 TDI", 2000, 200, 150, FuelType.Diesel, 320, 1900, 4);
                    // 700 step 2
                case "Ferrari":
                    return new AutomobileEngine("Ferrari F136 V8", 3500, 340, 490, FuelType.Petrol, 540, 4500, 8); 
                    // 1560 step 3
                case "Bugatti":
                    return new AutomobileEngine("Bugatti Veyron W16", 4000, 400, 1001, FuelType.Petrol, 1250, 8000, 16); // 3211 step 3
                case "H2O":
                    return new HighTechEngine("H2O Motor", 1000, 220, 580 , FuelType.Water, 1); // step 1 580 + 100 = 680
                case "Ion":
                    return new HighTechEngine("Ion X3", 2000, 400, 1320, FuelType.Ion, 2); //step 2 1520
                case "Plasma":
                    return new HighTechEngine("Vasimir Plasma Engine ", 3500, 600, 2860, FuelType.Plasma, 6); // step 3 3460
                default: throw new ArgumentException("There is no such a model!");
            }
        }

    }
}
