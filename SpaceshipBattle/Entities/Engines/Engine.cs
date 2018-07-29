using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities.Engine
{
    public class Engine : IEngine
    {
        public Engine(string model, int weight, int price, int power, int fuelCapacity, FuelType fuelType )
        {
            this.Model = model;
            this.Weight = weight;
            this.Price = price;
            this.Power = power;
            this.FuelCapacity = fuelCapacity;
            this.FuelType = fuelType;
        }

        public string Model { get; set; }

        public int Weight { get; set; }

        public int Price { get; set; }

        public int Power { get; set; }

        public int FuelCapacity { get; set; }

        public FuelType FuelType { get; set; }

    }
}
