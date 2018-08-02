using SpaceshipBattle.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Spaceships
{
    public class SpaceShipDesign
    {
        public static string[] DrossLeft  => new string[] { "Z)", " |||>", ": |[][]((0)-]", " |||>", "Z)" };
        public static string[] DrossaRight => new string[] { "(Z", "<||| ", "[-(000[][]| :", "<||| ", "(Z" };

        public static string[] FuturisticLeft => new string[] { "  { >", @"  {} \\\\\)", "zZ {########]]]]", "  {} /////)", "  { >", };
        public static string[] FuturisticRight => new string[] { "< }  ", "(///// {}  ", "[[[[########} Zz", @"(\\\\\ {}  ", "< }  ", };

    }
}
