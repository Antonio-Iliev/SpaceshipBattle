using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities
{
   public abstract class Ammunition : IAmmunition
    {
        public int Weight { get; set; }
        public int Damage { get; set; }
        public int Price { get; set; }
        // model amunicii ???
        public string Model { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               

        
    }
}
