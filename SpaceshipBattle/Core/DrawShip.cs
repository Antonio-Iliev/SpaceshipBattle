using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Entities;
using SpaceshipBattle.Entities.Spaceships;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core
{
    public static class DrawShip
    {

        public static void DrawShipPlayerOne(IPlayer player)
        {
            List<string> shipDesign = new List<string>();

            switch (player.Spaceship.Model)
            {
                case "Dross-Mashup Spaceship":
                    shipDesign.AddRange(SpaceShipDesign.DrossLeft);
                    break;
                case "Futuristic Spaceship":
                    shipDesign.AddRange(SpaceShipDesign.FuturisticLeft);
                    break;
            }

            int ofsetRow = shipDesign.Count / -2;
            foreach (string element in shipDesign)
            {
                Console.SetCursorPosition(0, player.Spaceship.PositionY + ofsetRow++);
                Console.Write(element);
            }
        }

        public static void DrawShipPlayerTwo(IPlayer player)
        {
            List<string> shipDesign = new List<string>();

            switch (player.Spaceship.Model)
            {
                case "Dross-Mashup Spaceship":
                    shipDesign.AddRange(SpaceShipDesign.DrossaRight);
                    break;
                case "Futuristic Spaceship":
                    shipDesign.AddRange(SpaceShipDesign.FuturisticRight);
                    break;
            }

            int ofsetRow = shipDesign.Count / -2; ;
            foreach (string element in shipDesign)
            {
                int offset = element.Length;
                Console.SetCursorPosition(Console.WindowWidth - offset, player.Spaceship.PositionY + ofsetRow++);
                Console.Write(element);
            }
        }

    }
}
