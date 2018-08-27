using SpaceshipBattle.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Spaceships
{
    public class SpaceShipDesign : ISpaceShipDesign
    {
        public IEnumerable<string> DrossLeft => new string[] { "Z)", " |||>", ": |[][]((0)-]", " |||>", "Z)" };
        public IEnumerable<string> DrossaRight => new string[] { "(Z", "<||| ", "[-(000[][]| :", "<||| ", "(Z" };

        public IEnumerable<string> FuturisticLeft => new string[] { "  { >", @"  {} \\\\\)", "zZ {########]]]]", "  {} /////)", "  { >", };
        public IEnumerable<string> FuturisticRight => new string[] { "< }  ", "(///// {}  ", "[[[[########} Zz", @"(\\\\\ {}  ", "< }  ", };

    }
}
