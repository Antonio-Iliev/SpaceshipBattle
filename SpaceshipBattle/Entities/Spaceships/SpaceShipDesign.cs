using SpaceshipBattle.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Spaceships
{
    public static class SpaceShipDesign
    {
        public static IEnumerable<string> DrossLeft  => new string[] { "Z)", " |||>", ": |[][]((0)-]", " |||>", "Z)" };
        public static IEnumerable<string> DrossaRight => new string[] { "(Z", "<||| ", "[-(000[][]| :", "<||| ", "(Z" };

        public static IEnumerable<string> FuturisticLeft => new string[] { "  { >", @"  {} \\\\\)", "zZ {########]]]]", "  {} /////)", "  { >", };
        public static IEnumerable<string> FuturisticRight => new string[] { "< }  ", "(///// {}  ", "[[[[########} Zz", @"(\\\\\ {}  ", "< }  ", };

    }
}
