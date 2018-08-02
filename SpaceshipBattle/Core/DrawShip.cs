using SpaceshipBattle.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core
{
    public class DrawShip : IDrawShip, ISpaceShipDesign
    {
        

        public void DrawShipPlayerOne(string[] shipDesign)
        {
            throw new NotImplementedException();
        }

        public void DrawShipPlayerTwo(string[] shipDesign)
        {
            throw new NotImplementedException();
        }

        public string SpaceShipDesign => throw new NotImplementedException();

    }
}
