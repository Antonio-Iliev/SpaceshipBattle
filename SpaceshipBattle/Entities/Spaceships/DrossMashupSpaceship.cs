using SpaceshipBattle.Entities.Engines;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Spaceships
{
    public class DrossMashupSpaceship : Spaceship
    {
        public override int FuelCapacity => 30;
        
        public DrossMashupSpaceship(ISpaceshipEngine engine, IArmour armour, IWeapon weapon, string model)
            : base(engine, armour, weapon, model)
        {
        }

        private readonly List<ISpaceshipEngine> enginesAllowed = new List<ISpaceshipEngine>()
        {
        };

        private readonly List<IArmour> armoursAllowed = new List<IArmour>()
        {
        };

        private readonly List<IWeapon> weaponsAllowed = new List<IWeapon>()
        {
        };

    }
}
