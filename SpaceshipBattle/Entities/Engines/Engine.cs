using SpaceshipBattle.Entities;
using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities.Engine
{
    public abstract class Engine : Item, IEngine
    {
        private string model;
        private int price;
        private int weight;
        private int power;
        private FuelType fuelType;

        protected Engine(int weight, int power, int fuelCapacity, FuelType fuelType)
        {
            this.Weight = weight;
            this.Power = power;
            this.FuelType = fuelType;
        }
        
        public override int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 100 || value > 500)
                {
                    throw new ArgumentException($"The weight of the engine should be between 100kg and 500kg.");
                }
                this.weight = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
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
    }
}
