﻿using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Spaceships
{
    public class FuturisticSpaceship : Spaceship
    {
        public FuturisticSpaceship(ISpaceshipEngine engine, IArmour armour, IWeapon weapon, string model)
            : base(engine, armour, weapon, model)
        {
        }

        public override int FuelCapacity => 25;
    }
}
