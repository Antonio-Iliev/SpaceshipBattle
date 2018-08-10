using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Spaceships
{
    public class FuturisticSpaceship : Spaceship
    {
        public FuturisticSpaceship(IEngine engine, IArmour armour, IWeapon weapon) : base(engine, armour, weapon)
        {
        }

        public override int FuelCapacity => 25;
    }
}
