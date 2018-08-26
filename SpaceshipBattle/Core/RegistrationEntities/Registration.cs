using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core.Common;
using SpaceshipBattle.Core.Registration;
using SpaceshipBattle.DataBase;
using SpaceshipBattle.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SpaceshipBattle.Core.RegistrationEntities
{
    public class Registration : IRegistration
    {
        private int positionRow;
        private int positionCol;
        private int rowOffset = 4;
        private int colOffset = 0;

        private Dictionary<string, string> parametersForPlayer;
        private readonly IDataBase dataBase;
        private readonly IApplicationInterface applicationInterface;
        private readonly ISelectingSpaceship selectingSpaceship;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Registration(
            IReader reader,
            IWriter writer,
            IDataBase dataBase,
            IApplicationInterface applicationInterface,
            ISelectingSpaceship selectingSpaceship)
        {
            this.reader = reader;
            this.writer = writer;
            this.dataBase = dataBase;
            this.applicationInterface = applicationInterface;
            this.selectingSpaceship = selectingSpaceship;
        }

        public Dictionary<string, string> ParametersForPlayer { get => new Dictionary<string, string>(this.parametersForPlayer); }

        public string RegistrationForPlayer()
        {
            parametersForPlayer = new Dictionary<string, string>();

            ChooseName();
            parametersForPlayer.AppendDictionary(selectingSpaceship.ChooseSpaceShip());

            return $" >>> " + parametersForPlayer["name"] + ". <<<< -You are ready for fight!!!";
        }

        //Choosing player name
        public string ChooseName()
        {
            this.positionRow = (applicationInterface.WindowHeight / 2) - rowOffset;
            this.positionCol = (applicationInterface.WindowWidth / 2) - colOffset;

            // Additional information for user
            writer.WriteTextCenter(this.positionCol, this.positionRow++, $"Welcome to space fight arena!");
            writer.WriteTextCenter(this.positionCol, this.positionRow++, "Enter your name:");

            writer.WriteTextAtPosition(positionCol - 10, positionRow + 1, ">>>> ");

            string nameOfPlayer = reader.ReadLine();
            bool isValid = false;
            while (!isValid)
            {
                // Checks whether the player's name is valid
                if (String.IsNullOrEmpty(nameOfPlayer) || String.IsNullOrWhiteSpace(nameOfPlayer)
                    || nameOfPlayer.Length < 3 || nameOfPlayer.Length > 35)
                {

                    // Clean invalid name
                    writer.WriteTextAtPosition(positionCol - 5, positionRow + 1, new string(' ', nameOfPlayer.Length));

                    // Show warning message if player assign invalid name
                    writer.SetTextColor(Colors.Red);
                    writer.WriteTextCenter(positionCol, positionRow + 3, "Name must be between 3 and 35 characters");
                    writer.SetTextColor(Colors.Cyan);

                    // Assign new player name
                    writer.SetCursorPosition(positionCol - 5, positionRow + 1);
                    nameOfPlayer = reader.ReadLine();
                }
                else
                {
                    // Add player name to commands
                    parametersForPlayer.Add("name", nameOfPlayer);
                    isValid = true;
                }
            }
            writer.ClearScreen();

            return "Player name is set!";
        }


    }
}
