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
        public IEngine CreatEngine(string model, int weight, int price, int power, int fuelCapacity, FuelType fuelType)
        {
            throw new NotImplementedException();
        }
    }
}
