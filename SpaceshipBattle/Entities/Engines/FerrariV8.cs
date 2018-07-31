using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Engines
{
    public class FerrariV8 : Engine
    {
        private const string modelValue = "Ferrari F136 V8";
        private const int priceValue = 2000;
        private const int weightValue = 400;
        private const int powerValue = 483;
        private const int fuelCapacityValue = 100;
        private const FuelType fuelTypeValue = FuelType.Petrol;

        public FerrariV8() : base(modelValue, priceValue, weightValue, powerValue, fuelCapacityValue, fuelTypeValue)
        {

        }
    }
}
