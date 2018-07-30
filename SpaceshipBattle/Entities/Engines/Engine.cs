using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities.Engine
{
    public abstract class Engine : IEngine
    {
        public string Model { get; set; }

        public int Price { get; set; } 

        public int Weight { get; set;} 

        public int Power { get; set; }

        public int FuelCapacity { get; set; }

        public FuelType FuelType { get; set; }
    }
}
