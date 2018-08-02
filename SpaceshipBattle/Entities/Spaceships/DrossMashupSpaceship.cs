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
        private readonly List<IEngine> enginesAllowed = new List<IEngine>()
        {
            
        };

        private readonly List<string> armoursAllowed = new List<string>()
        {
            
        };

        private readonly List<string> weaponsAllowed = new List<string>()
        {

        };


    }
}
