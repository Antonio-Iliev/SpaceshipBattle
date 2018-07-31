using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Engines
{
    public class AutomobileEngine : Engine
    {
        public AutomobileEngine(string model, int price, int weight, int power, int fuelCapacity, FuelType fuelType) : base(model, price, weight, power, fuelCapacity, fuelType)
        {
        }
    }
}
