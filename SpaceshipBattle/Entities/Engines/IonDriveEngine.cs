using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Engines
{
    public class IonDriveEngine : Engine
    {
        private const string modelValue = "Ion X3";
        private const int priceValue = 1000;
        private const int weightValue = 600;
        private const int powerValue = 400;
        private const int fuelCapacityValue = 40;
        private const FuelType fuelTypeValue = FuelType.Ion;

        protected IonDriveEngine() : base(modelValue, priceValue, weightValue, powerValue, fuelCapacityValue, fuelTypeValue)
        {

        }
    }
}
