﻿using SpaceshipBattle.Entities;
using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities.Engine
{
    public abstract class Engine : Item, IEngine
    {
        private const int MinPowerValue = 0;
        private const int MaxPowerValue = 1000;

        private string model;
        private int price;
        private int weight;
        private int power;
        private FuelType fuelType;
        
        protected Engine(string model, int price, int weight, int power, FuelType fuelType)
        {
            base.Model = model;
            base.Weight = weight;
            base.Price = price;
            this.Power = power;
            this.FuelType = fuelType;
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
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
       
        public abstract int EngineCoefEfficiency { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Power: { this.Power}");
            sb.AppendLine($"Fuel type: { this.FuelType}");
            
            return sb.ToString();
        }
    }
}
