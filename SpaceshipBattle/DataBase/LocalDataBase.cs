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

        // Weapons
        public readonly List<string> ak47Weapon = new List<string>() { "AK47", "2000", "20", "8", "4", "200", "30" };
        public readonly List<string> cannonWeapon = new List<string>() { "Cannon", "3000", "30", "12", "2", "50", "1" };
        public readonly List<string> laserWeapon = new List<string>() { "Laser", "2500", "20", "10", "3", "100", "25" };
        public readonly List<string> plasmaWeapon = new List<string>() { "Plasma Weapon", "4000", "40", "15", "2", "40", "2" };

        // Engines
        public readonly List<string> trabantMotorEngine = new List<string>() { "Trabant Motor", "1000", "110", "26", "Petrol", "55", "594", "2" };
        public readonly List<string> vwtdiEngine = new List<string>() { "VW 1.9 TDI", "1500", "200", "150", "Diesel", "320", "1900", "4" };
        public readonly List<string> ferrariEngine = new List<string>() { "Ferrari V12 GT", "3500", "340", "789", "Petrol", "718", "6500", "12" };
        public readonly List<string> bugattiEngine = new List<string>() { "Bugatti W16", "4000", "400", "1001", "Petrol", "1250", "8000", "16" };
        public readonly List<string> h2oMotorEngine = new List<string>() { "H2O Motor", "1000", "220", "980", "Water", "1" };
        public readonly List<string> ionEngine = new List<string>() { "Ion X3", "2000", "400", "2120", "Ion", "2" };
        public readonly List<string> vasimirPlasmaEngine = new List<string>() { "Vasimir Plasma Engine ", "3500", "600", "2860", "Plasma", "6" };

        // Armours
        public readonly List<string> recycledPaperArmour = new List<string>() { "Recycled Paper", "1000", "50", "20", "0", "2", "Paper" };
        public readonly List<string> brickCageArmour = new List<string>() { "Brick cage", "1500", "800", "25", "6", "0", "Brick" };
        public readonly List<string> aerogelCoverArmour = new List<string>() { "Aerogel cover", "2000", "500", "30", "2", "5", "Aerogel" };
        public readonly List<string> fullerenesArmour = new List<string>() { "Fullerenes Armour", "3500", "200", "40", "7", "3", "Carbon" };
        public readonly List<string> switzArmour = new List<string>() { "Switz Armour", "2500", "800", "35", "3", "2", "Steel" };
        public readonly List<string> bubbleFieldArmour = new List<string>() { "Bubble Field", "1600", "100", "12", "4", "1", "Plasma" };
        public readonly List<string> plasmaFieldArmour = new List<string>() { "Plasma Field", "2800", "100", "35", "2", "8", "Plasma" };
        public readonly List<string> antiMatterFieldArmour = new List<string>() { "Anti Matter Field", "5000", "450", "65", "0", "10", "AntiMatter" };

    }
}
