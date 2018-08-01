using SpaceshipBattle.Entities;
using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities.Armour
{
    public abstract class Armour : Item, IArmour
    {
        public int Points { get; set; }


        public int  MyProperty { get; set; } 
    }
}
