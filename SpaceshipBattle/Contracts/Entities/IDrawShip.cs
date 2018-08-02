using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts.Entities
{
    public interface IDrawShip
    {
        void DrawShipPlayerOne(string[] shipDesign);
        void DrawShipPlayerTwo(string[] shipDesign);
    }
}
