using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core
{
    public class DrawShip
    {

        public static void DrawShipPlayerOne(IPlayer player, string[] shipDesign)
        {
            int ofsetRow = shipDesign.Length / -2;
            foreach (string element in shipDesign)
            {
                Console.SetCursorPosition(0, player.Spaceship.PositionY + ofsetRow++);
                Console.Write(element);
            }
        }

        public static void DrawShipPlayerTwo(IPlayer player, string[] shipDesign)
        {
            int ofsetRow = shipDesign.Length / -2; ;
            foreach (string element in shipDesign)
            {
                int offset = element.Length;
                Console.SetCursorPosition(Console.WindowWidth - offset, player.Spaceship.PositionY + ofsetRow++);
                Console.Write(element);
            }
        }

    }
}
