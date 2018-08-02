using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts
{
    public interface IItem
    {
        string Model { get; }

        int Price { get; }

        int Weight { get; }
    }
}
