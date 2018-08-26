using System.Collections.Generic;

namespace SpaceshipBattle.DataBase
{
    public interface IDataBase
    {
        string[] ComponentsInSpaceship { get; }
        Dictionary<string, int> DrossMashupArmours { get; }
        Dictionary<string, int> DrossMashupEngines { get; }
        Dictionary<string, int> DrossMashupWeapons { get; }
        Dictionary<string, int> FuturisticArmours { get; }
        Dictionary<string, int> FuturisticEngines { get; }
        Dictionary<string, int> FuturisticWeapons { get; }
        string[] SpaceshipNames { get; }
    }
}