using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Contracts.Factories
{
    public interface IEngineFactory
    {
        IEngine CreatEngine(string model, int weight, int price, int power, int fuelCapacity, FuelType fuelType);
    }
}
