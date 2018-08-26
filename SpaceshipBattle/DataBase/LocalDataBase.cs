using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.DataBase
{
    public class LocalDataBase : IDataBase
    {
        // Different Spaceships
        public string[] SpaceshipNames { get; } = new string[] { "Dross-Mashup Spaceship", "Futuristic Spaceship" };

        // Components witch can be implemented in Spaceships
        public string[] ComponentsInSpaceship { get; } = new string[] { "Weapon", "Engine", "Armour" };

        // Weapon witch can use in Dross-Mashup Spaceships
        public Dictionary<string, int> DrossMashupWeapons { get; } = new Dictionary<string, int>
                        { { "AK47", 2000 }, {"Cannon", 3000 } };

        // Weapon witch can use in Futuristic Spaceships
        public Dictionary<string, int> FuturisticWeapons { get; } = new Dictionary<string, int>
                        { {"Laser", 2500 }, {"Plasma Weapon", 4000 } };

        // Engines witch can use in Dross-Mashup Spaceships
        public Dictionary<string, int> DrossMashupEngines { get; } = new Dictionary<string, int>
        { { "Trabant Motor", 1000 }, {"VW 1.9 TDI", 1500 }, {"Ferrari V12 GT", 3500 }, {"Bugatti W16", 4000 } };

        // Engines witch can use in Futuristic Spaceships
        public Dictionary<string, int> FuturisticEngines { get; } = new Dictionary<string, int>
        { { "H2O Motor", 1000 }, {"Ion X3", 2000 }, {"Vasimir Plasma Engine", 3500 } };

        //  Armours witch can use in Dross-Mashup Spaceships
        public Dictionary<string, int> DrossMashupArmours { get; } = new Dictionary<string, int>
        {{ "Recycled Paper", 1000 }, {"Brick cage",1500 }, {"Aerogel cover",2000 }, {"Bubble Field", 1600 },  {"Plasma Field", 3800 } };

        // Armours witch can use in Futuristic Spaceships
        public Dictionary<string, int> FuturisticArmours { get; } = new Dictionary<string, int>
        {{"Aerogel cover",2000 },  {"Fullerenes Armour", 3500 }, { "Switz Armour", 2500 }, {"Plasma Field", 3800 }, {"Anti Matter Fields", 5000 } };

    }
}
