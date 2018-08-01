using SpaceshipBattle.Contracts.Entities.Engines;
using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Engines
{
    public class HighTechEngine : Engine, IHighTechEngine
    {
        private const int MinThrustValue = 0;
        private const int MaxThrustValue = 1500;

        private int thrust;

        protected HighTechEngine(string model, int price, int weight, int power, FuelType fuelType, int thrust) : base(model, price, weight, power, fuelType)
        {
            this.Thrust = thrust;
        }

        //[kN.m] - 1000 N.m = 1 kN.m
        public int Thrust
        {
            get
            {
                return this.thrust;
            }
            set
            {
                if (value < MinThrustValue || thrust > MaxThrustValue)
                {
                    throw new ArgumentOutOfRangeException($"The thrust of engine cannot be less than {MinThrustValue } or more than {MaxThrustValue}.");
                }
                this.thrust = value;
            }
        }

        public override int EngineCoefEfficiency => this.Power + this.Thrust;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Thrust: { this.Thrust}");

            return sb.ToString();
        }
    }
}
