using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Contracts
{
    public interface IItem
    {
        int Weight { get; }
        int Price { get; }
        string Model { get; }
    }
}
