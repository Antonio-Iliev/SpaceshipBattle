using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Engines
{
    public class TDI : Engine
    {
        private const string modelValue = "1.9 TDI";
        private const int priceValue = 1000;
        private const int weightValue = 250;
        private const int powerValue = 110;
        private const int fuelCapacityValue = 80;
        private const FuelType fuelTypeValue = FuelType.Diesel;
        
        public TDI() : base(modelValue, priceValue, weightValue, powerValue, fuelCapacityValue, fuelTypeValue)
        {

        }
    }
}
