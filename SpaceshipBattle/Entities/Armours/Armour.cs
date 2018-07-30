using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities.Armour
{
    public abstract class Armour : IArmour
    {
        public string Model { get; set; }

        public int Points { get; set; }

        public int Price { get; set; }

        public int Weight { get; set; }  
    }
}
