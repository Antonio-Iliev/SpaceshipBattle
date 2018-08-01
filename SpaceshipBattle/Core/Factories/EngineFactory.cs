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
                //case "TDI":
                //    return new AutomobileEngine("1.9 TDI", 1000, 250, 110, FuelType.Diesel);
                //case "V8":
                //    return new AutomobileEngine("V8", 500, 250, 110, 200, FuelType.Diesel);

                default: throw new ArgumentException("There is no such a model!");
            }
        }

        //DATA
        //string modelValue = "H2O Motor";
        //int priceValue = 2000;
        //int weightValue = 100;
        //int powerValue = 75;
        //int fuelCapacityValue = 50;
        //FuelType fuelTypeValue = FuelType.Water;

        //string modelValue = "Ion X3";
        //int priceValue = 1000;
        //int weightValue = 600;
        //int powerValue = 400;
        //int fuelCapacityValue = 40;
        //FuelType fuelTypeValue = FuelType.Ion;


    }
}
