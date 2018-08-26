using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.DataBase;
using SpaceshipBattle.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceshipBattle.Core.Registration
{
    public class SelectingSpaceship : ISelectingSpaceship
    {
        private readonly IApplicationInterface appInterface;
        private readonly IDataBase dataBase;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IMenu menu;
        private readonly IFilterComponents filterComponents;

        private int positionRow;
        private int positionCol;
        private int rowOffset = 4;
        private int colOffset = 0;
        private Dictionary<string, string> parameters;
        private int playerAvailableМoney;

        public SelectingSpaceship(
            IApplicationInterface applicationInterface,
            IDataBase dataBase,
            IWriter writer,
            IReader reader,
            IMenu menu,
            IFilterComponents filterComponents)
        {
            this.appInterface = applicationInterface;
            this.dataBase = dataBase;
            this.writer = writer;
            this.reader = reader;
            this.menu = menu;
            this.filterComponents = filterComponents;
        }

        public int PlayerAvailableМoney
        {
            get => this.playerAvailableМoney;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Player can not hold a loan!");
                }
                this.playerAvailableМoney = value;
            }
        }

        public Dictionary<string, string> ChooseSpaceShip()
        {

            // Arrange
            this.parameters = new Dictionary<string, string>();
            playerAvailableМoney = 10000;

            this.positionRow = (appInterface.WindowHeight / 2) - rowOffset - (this.dataBase.SpaceshipNames.Length / 2);
            this.positionCol = (appInterface.WindowWidth / 2) - colOffset;
            int focusPosition = 0;

            var componentList = this.dataBase.SpaceshipNames;
            int lengthOfElements = this.dataBase.SpaceshipNames.Length;

            while (true)
            {
                if (reader.KeyAvailable())
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (focusPosition > 0)
                        {
                            focusPosition--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (focusPosition < lengthOfElements - 1)
                        {
                            focusPosition++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        this.parameters.Add("ship", this.dataBase.SpaceshipNames[focusPosition]);
                        writer.ClearScreen();
                        return this.parameters.AppendDictionary(ChooseComponent());
                    }
                }

                // write info message
                this.writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your Spaceship:");
                this.writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "__________________");

                // Draw menu for Spaceship
                this.menu.DrawMenu(componentList, this.positionCol, this.positionRow, focusPosition);

            }

        }

        public Dictionary<string, string> ChooseComponent()
        {
            this.positionRow = (appInterface.WindowHeight / 2) - rowOffset - (this.dataBase.ComponentsInSpaceship.Length / 2);
            this.positionCol = (appInterface.WindowWidth / 2) - colOffset;
            int focusPosition = 0;

            List<string> componentList = new List<string>(this.dataBase.ComponentsInSpaceship);

            while (true)
            {
                if (reader.KeyAvailable())
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (focusPosition > 0)
                        {
                            focusPosition--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (focusPosition < componentList.Count - 1)
                        {
                            focusPosition++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        // choosing component directory
                        string componet = componentList[focusPosition].ToLower();
                        this.parameters.Add(componet, ChooseShipItem(componet));
                        componentList.Remove(componentList[focusPosition]);
                        focusPosition = 0;

                        this.writer.ClearScreen();
                    }
                }

                if (componentList.Count == 0)
                {
                    this.writer.ClearScreen();
                    return this.parameters;
                }
                else
                {
                    // info message
                    this.writer.WriteTextCenter(this.positionCol, this.positionRow - 4, "You have " + playerAvailableМoney + " GC");
                    this.writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose component for your ship:");
                    this.writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "_____________________");

                    // Draw Menu for ship components
                    this.menu.DrawMenu(componentList, this.positionCol, this.positionRow, focusPosition);
                }
            }
        }

        private string ChooseShipItem(string item)
        {
            Dictionary<string, int> items = this.filterComponents.SelectElementsByShipType(this.parameters, item, playerAvailableМoney);

            this.positionRow = (appInterface.WindowHeight / 2) - rowOffset - (items.Count / 2);
            this.positionCol = (appInterface.WindowWidth / 2) - colOffset;

            int focusPosition = 0;

            while (true)
            {
                if (reader.KeyAvailable())
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (focusPosition > 0)
                        {
                            focusPosition--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (focusPosition < items.Count - 1)
                        {
                            focusPosition++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        playerAvailableМoney -= items.Values.ElementAt(focusPosition);
                        return items.Keys.ElementAt(focusPosition);
                    }
                }

                // info message
                this.writer.WriteTextCenter(this.positionCol, this.positionRow - 4, "You have " + playerAvailableМoney + " GC");
                this.writer.WriteTextCenter(this.positionCol, this.positionRow - 2, $"Choose your spaceship {item}!");
                this.writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "_________________________");

                // Draw weapon menu
                this.menu.DrawMenu(items, this.positionCol, this.positionRow, focusPosition);
            }
        }
    }
}
