using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Contracts
{
    public interface IArmour : IItem
    {
        int Points { get; }
    }
}
