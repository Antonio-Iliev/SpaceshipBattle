using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Engines
{
    public class H2OMotor : Engine
    {
        private const string modelValue = "H2O Motor";
        private const int priceValue = 2000;
        private const int weightValue = 100;
        private const int powerValue = 75;
        private const int fuelCapacityValue = 50;
        private const FuelType fuelTypeValue = FuelType.Water;

        protected H2OMotor() : base(modelValue, priceValue, weightValue, powerValue, fuelCapacityValue, fuelTypeValue)
        {

        }
    }
}
