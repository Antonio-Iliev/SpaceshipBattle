using SpaceshipBattle.Contracts.Entities.Engines;
using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Engines
{
    public class AutomobileEngine : Engine, IAutomobileEngine
    {
        private const int MinPowerValue = 1;
        private const int MaxPowerValue = 1500;
        private const int MinTorqueValue = 0;
        private const int MaxTorqueValue = 1500;
        private const int MinCapacityValue = 500;
        private const int MaxCapacityValue = 10000;
        private const int MinCylinderCountValue = 1;
        private const int MaxCylinderCountValue = 20;

        private int torque;
        private int capacity;
        private int cylinderCount;

        public AutomobileEngine(string model, int price, int weight, int power, FuelType fuelType, int torque, int capacity, int cylinderCount) : base(model, price, weight, power, fuelType)
        {
            this.Torque = torque;
            this.Capacity = capacity;
            this.CylinderCount = cylinderCount;
        }
        public override int Power
        {
            get
            {
                return base.Power;
            }
            protected set
            {
                if (value < MinCapacityValue || value > MaxCapacityValue)
                {
                    throw new ArgumentOutOfRangeException($"The capacity of engine cannot be less than {MinCapacityValue } or more than {MaxCapacityValue}.");
                }
                base.Power = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value < MinCapacityValue || value > MaxCapacityValue)
                {
                    throw new ArgumentOutOfRangeException($"The capacity of engine cannot be less than {MinCapacityValue } or more than {MaxCapacityValue}.");
                }
                this.capacity = value;
            }
        }

        //[N.m]
        public int Torque
        {
            get
            {
                return this.torque;
            }
            set
            {
                if (value < MinTorqueValue || value > MaxTorqueValue)
                {
                    throw new ArgumentOutOfRangeException($"The torque of engine cannot be less than {MinTorqueValue } or more than {MaxTorqueValue}.");
                }
                this.torque = value;
            }
        }

        public int CylinderCount
        {
            get
            {
                return this.cylinderCount;
            }
            set
            {
                if (value < MinCylinderCountValue || value > MaxCylinderCountValue)
                {
                    throw new ArgumentOutOfRangeException($"The count of cylinders cannot be less than {MinCylinderCountValue } or more than {MaxCylinderCountValue}.");
                }
                this.cylinderCount = value;
            }
        }

        public override int EngineEfficiencyCoef => (int)Math.Round((this.Power + this.Torque + this.Capacity / 10 + this.CylinderCount * 10) / 1000d);
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Capacity: { this.Capacity}");
            sb.AppendLine($"Torque: { this.Torque}");
            sb.AppendLine($"Count of cylinders: { this.CylinderCount}");

            return sb.ToString();
        }
    }
}
