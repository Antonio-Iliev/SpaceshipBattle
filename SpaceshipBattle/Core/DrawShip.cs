using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Spaceships;
using System;
using System.Collections.Generic;

namespace SpaceshipBattle.Core
{
    public class DrawShip : IDrawShip
    {
        private readonly ISpaceShipDesign spaceShipDesign;

        public DrawShip(ISpaceShipDesign spaceShipDesign)
        {
            this.spaceShipDesign = spaceShipDesign;
        }

        // Draw left player 
        public string DrawShipPlayerOne(IPlayer player)
        {
            List<string> shipDesign = new List<string>();

            switch (player.Spaceship.Model)
            {
                case "Dross-Mashup Spaceship":
                    shipDesign.AddRange(spaceShipDesign.DrossLeft);
                    break;
                case "Futuristic Spaceship":
                    shipDesign.AddRange(spaceShipDesign.FuturisticLeft);
                    break;
            }

            int ofsetRow = shipDesign.Count / -2;
            foreach (string element in shipDesign)
            {
                Console.SetCursorPosition(0, player.Spaceship.PositionY + ofsetRow++);
                Console.Write(element);
            }

            return $"Player One use {player.Spaceship.Model}";
        }

        // Draw right player
        public string DrawShipPlayerTwo(IPlayer player)
        {
            List<string> shipDesign = new List<string>();

            switch (player.Spaceship.Model)
            {
                case "Dross-Mashup Spaceship":
                    shipDesign.AddRange(spaceShipDesign.DrossaRight);
                    break;
                case "Futuristic Spaceship":
                    shipDesign.AddRange(spaceShipDesign.FuturisticRight);
                    break;
            }

            int ofsetRow = shipDesign.Count / -2; ;
            foreach (string element in shipDesign)
            {
                int offset = element.Length;
                Console.SetCursorPosition(Console.WindowWidth - offset, player.Spaceship.PositionY + ofsetRow++);
                Console.Write(element);
            }

            return $"Player Two use {player.Spaceship.Model}";
        }
    }
}
