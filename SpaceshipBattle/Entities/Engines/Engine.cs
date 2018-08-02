using SpaceshipBattle.Entities;
using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Engines
{
    public abstract class Engine : Item, IEngine
    {
        private const int MinPowerValue = 1;
        private const int MaxPowerValue = 10000;

        private int power;
        private FuelType fuelType;
        
        protected Engine(string model, int price, int weight, int power, FuelType fuelType) : base(model, price, weight)
        {
            this.Power = power;
            this.FuelType = fuelType;
        }

        public virtual int Power
        {
            get
            {
                return this.power;
            }
            protected set
            {
                if (value < MinPowerValue || value > MaxPowerValue)
                {
                    throw new ArgumentOutOfRangeException($"The power of engine cannot be less than {MinPowerValue } or more than {MaxPowerValue}.");
                }
                this.power = value;
            }
        }
        
        public FuelType FuelType
        {
            get
            {
                return this.fuelType;
            }
            private set
            {
                this.fuelType = value;
            }
        }
       
        public abstract int EngineEfficiencyCoef { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Power: { this.Power}hp");
            sb.Append($"Fuel type: { this.FuelType}");
            
            return sb.ToString();
        }
    }
}
