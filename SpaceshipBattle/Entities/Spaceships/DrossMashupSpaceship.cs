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
        
        public DrossMashupSpaceship(IEngine engine, IArmour armour, IWeapon weapon) : base(engine, armour, weapon)
        {

        }

        private readonly List<IEngine> enginesAllowed = new List<IEngine>()
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
