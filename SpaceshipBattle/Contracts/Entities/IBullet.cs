using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Contracts
{
    public interface IBullet
    {
        int PositionX { get; }

        int PositionY { get; }
    }
}
