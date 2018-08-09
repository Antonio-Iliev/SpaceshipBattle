using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Spaceships
{
    public class FuturisticSpaceship : Spaceship
    {
        public FuturisticSpaceship(IEngine engine, IArmour armour, IWeapon weapon, string[] design) : base(engine, armour, weapon, design)
        {
        }

        public override int FuelCapacity => 25;
    }
}
