using SpaceshipBattle.Entities.Engines;
using SpaceshipsBattle.Contracts;
using SpaceshipsBattle.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Spaceships
{
    public class DrossMashupSpaceship : Spaceship
    {
        private readonly List<string> enginesAllowed = new List<string>()
        {
            nameof(TDI)
        };

        private readonly List<string> armoursAllowed = new List<string>()
        {
            
        };

        private readonly List<string> weaponsAllowed = new List<string>()
        {

        };

        protected DrossMashupSpaceship(string model, int health, int fuel, IArmour armour, IEngine engine, IWeapon weapon) : base(model, health, fuel, armour, engine, weapon)
        {

        }
    }
}
