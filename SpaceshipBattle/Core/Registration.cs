using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SpaceshipBattle.Core
{
    public class Registration : IRegistration
    {
        private int positionRow;
        private int positionCol;
        private int rowOffset = 4;
        private int colOffset = 0;
        private int availableМoney = 10000;

        private readonly string[] spaceshipNames = new string[] { "Dross-Mashup Spaceship", "Futuristic Spaceship" };
        private readonly string[] componentsInSpaceship = new string[] { "Weapon", "Engine", "Armour" };

        private readonly Dictionary<string, int> drossMashupWeapons = new Dictionary<string, int>
                        { { "AK47", 2000 }, {"Cannon", 3000 } };

        private readonly Dictionary<string, int> futuristicWeapons = new Dictionary<string, int>
                        { {"Laser", 2500 }, {"Plasma Weapon", 4000 } };

        private readonly Dictionary<string, int> drossMashupEngines = new Dictionary<string, int>
        { { "Trabant Motor", 1000 }, {"VW 1.9 TDI", 1500 }, {"Ferrari V12 GT", 3500 }, {"Bugatti W16", 4000 } };

        private readonly Dictionary<string, int> futuristicEngines = new Dictionary<string, int>
        { { "H2O Motor", 1000 }, {"Ion X3", 2000 }, {"Vasimir Plasma Engine", 3500 } };

        private readonly Dictionary<string, int> drossMashupArmours = new Dictionary<string, int>
        {{ "Recycled Paper", 1000 }, {"Brick cage",1500 }, {"Aerogel cover",2000 }, {"Bubble Field", 1600 },  {"Plasma Field", 3800 } };

        private readonly Dictionary<string, int> futuristicArmours = new Dictionary<string, int>
        {{"Aerogel cover",2000 },  {"Fullerenes Armour", 3500 }, { "Switz Armour", 2500 }, {"Plasma Field", 3800 }, {"Anti Matter Fields", 5000 } };

        private Dictionary<string, string> parametersForPlayer = new Dictionary<string, string>();

        public Registration(IReader reader, IWriter writer)
        {
            this.Reader = reader;
            this.Writer = writer;
        }

        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }

        public Dictionary<string, string> ParametersForPlayer { get => new Dictionary<string, string>(this.parametersForPlayer); }

        //Choosing player name
        public void ChooseName()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset;
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            // Additional information for user
            Writer.WriteTextCenter(this.positionCol, this.positionRow++, $"Welcome to space fight arena!");
            Writer.WriteTextCenter(this.positionCol, this.positionRow++, "Enter your name:");

            Writer.WriteTextAtPosition(positionCol - 10, positionRow + 1, ">>>> ");

            string nameOfPlayer = Reader.ReadLine();
            bool isValid = false;
            while (!isValid)
            {
                // Checks whether the player's name is valid
                if (String.IsNullOrEmpty(nameOfPlayer) || String.IsNullOrWhiteSpace(nameOfPlayer)
                    || nameOfPlayer.Length < 3 || nameOfPlayer.Length > 35)
                {

                    // Clean invalid name
                    Writer.WriteTextAtPosition(positionCol - 5, positionRow + 1, new string(' ', nameOfPlayer.Length));

                    // Show warning message if player assign invalid name
                    Writer.SetTextColor(Colors.Red);
                    Writer.WriteTextCenter(positionCol, positionRow + 3, "Name must be between 3 and 35 characters");
                    Writer.SetTextColor(Colors.Cyan);

                    // Assign new player name
                    Writer.WriteTextAtPosition(positionCol - 5, positionRow + 1);
                    nameOfPlayer = Reader.ReadLine();
                }
                else
                {
                    // Add player name to commands
                    parametersForPlayer.Add("name", nameOfPlayer);
                    isValid = true;
                }
            }
            Writer.ClearScreen();
        }

        public void ChooseSpaceShip()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (spaceshipNames.Length / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;
            int focusPosition = 0;

            int lengthOfElements = spaceshipNames.Length;

            while (true)
            {
                if (Console.KeyAvailable)
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
                        parametersForPlayer.Add("ship", this.spaceshipNames[focusPosition]);
                        Console.Clear();
                        return;
                    }
                }

                Writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your Spaceship:");
                Writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "__________________");

                for (int i = 0; i < lengthOfElements; i++)
                {
                    if (focusPosition == i)
                    {
                        Writer.WriteMenu(positionCol, positionRow + 1 + i, spaceshipNames[i]);
                    }
                    else
                    {
                        Writer.WriteTextCenter(positionCol, positionRow + 1 + i, spaceshipNames[i]);
                    }
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Thread.Sleep(100);
                Console.Clear();
            }

        }

        public void ChooseComponent()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (componentsInSpaceship.Length / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;
            int focusPosition = 0;

            List<string> componentList = new List<string>(componentsInSpaceship);

            while (true)
            {
                if (Console.KeyAvailable)
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
                        string componet = componentList[focusPosition].ToLower();
                        switch (componet)
                        {
                            case "weapon":
                                parametersForPlayer.Add(componet, ChooseWeapon());
                                componentList.Remove(componentList[focusPosition]);
                                focusPosition = 0;
                                Console.Clear();
                                break;

                            case "engine":
                                parametersForPlayer.Add(componet, ChooseEngine());
                                componentList.Remove(componentList[focusPosition]);
                                focusPosition = 0;
                                Console.Clear();
                                break;
                            case "armour":
                                parametersForPlayer.Add(componet, ChooseArmour());
                                componentList.Remove(componentList[focusPosition]);
                                focusPosition = 0;
                                Console.Clear();
                                break;
                        }
                    }
                }

                if (componentList.Count == 0)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose component for your ship:");
                    Writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "_____________________");

                    for (int i = 0; i < componentList.Count; i++)
                    {
                        if (focusPosition == i)
                        {
                            Writer.WriteMenu(positionCol, positionRow + 1 + i, componentList[i]);
                        }
                        else
                        {
                            Writer.WriteTextCenter(positionCol, positionRow + 1 + i, componentList[i]);
                        }
                    }

                    Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                    Thread.Sleep(100);
                    Console.Clear();
                }
            }
        }

        private string ChooseWeapon()
        {
            Dictionary<string, int> weapons = SelectElementsByShipType("weapon");

            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (weapons.Count / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            int lengthOfElements = weapons.Count;
            int focusPosition = 0;

            while (true)
            {
                if (Console.KeyAvailable)
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
                        availableМoney -= weapons.Values.ElementAt(focusPosition);
                        return weapons.Keys.ElementAt(focusPosition);
                    }
                }

                Writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your weapon of destruction:");
                Writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "_________________________");

                int elementRow = 1;
                for (int i = 0; i < lengthOfElements; i++)
                {
                    string str = weapons.Keys.ElementAt(i) + "  - cost: " + weapons.Values.ElementAt(i) + " GC";
                    if (focusPosition == i)
                    {
                        Writer.WriteMenu(positionCol, positionRow + elementRow, str);
                    }
                    else
                    {
                        Writer.WriteTextCenter(positionCol, positionRow + elementRow, str);
                    }
                    elementRow++;
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private string ChooseEngine()
        {
            Dictionary<string, int> engines = SelectElementsByShipType("engine");

            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (engines.Count / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            int lengthOfElements = engines.Count;
            int focusPosition = 0;

            while (true)
            {
                if (Console.KeyAvailable)
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
                        availableМoney -= engines.Values.ElementAt(focusPosition);
                        return engines.Keys.ElementAt(focusPosition);
                    }
                }

                Writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your flying power (engine):");
                Writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "___________________________");

                int elementRow = 1;
                for (int i = 0; i < lengthOfElements; i++)
                {
                    string str = engines.Keys.ElementAt(i) + "  - cost: " + engines.Values.ElementAt(i) + " GC";
                    if (focusPosition == i)
                    {
                        Writer.WriteMenu(positionCol, positionRow + elementRow, str);
                    }
                    else
                    {
                        Writer.WriteTextCenter(positionCol, positionRow + elementRow, str);
                    }
                    elementRow++;
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private string ChooseArmour()
        {
            Dictionary<string, int> armours = SelectElementsByShipType("armour");

            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (armours.Count / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            int lengthOfElements = armours.Count;
            int focusPosition = 0;

            while (true)
            {
                if (Console.KeyAvailable)
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
                        availableМoney -= armours.Values.ElementAt(focusPosition);
                        return armours.Keys.ElementAt(focusPosition);
                    }
                }

                Writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your impenetrable skin (armour):");
                Writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "___________________________");

                int elementRow = 1;
                for (int i = 0; i < lengthOfElements; i++)
                {
                    string str = armours.Keys.ElementAt(i) + "  - cost: " + armours.Values.ElementAt(i) + " GC";
                    if (focusPosition == i)
                    {
                        Writer.WriteMenu(positionCol, positionRow + elementRow, str);
                    }
                    else
                    {
                        Writer.WriteTextCenter(positionCol, positionRow + elementRow, str);
                    }
                    elementRow++;
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private Dictionary<string, int> SelectElementsByShipType(string element)
        {
            if (this.ParametersForPlayer.Keys.Contains("ship"))
            {
                switch (this.ParametersForPlayer["ship"])
                {
                    case "Dross-Mashup Spaceship":
                        switch (element)
                        {
                            case "armour":
                                return SelectElementsByPrice(drossMashupArmours);
                            case "weapon":
                                return SelectElementsByPrice(drossMashupWeapons);
                            case "engine":
                                return SelectElementsByPrice(drossMashupEngines);
                            default:
                                return null;
                        }
                    case "Futuristic Spaceship":
                        switch (element)
                        {
                            case "armour":
                                return SelectElementsByPrice(futuristicArmours);
                            case "weapon":
                                return SelectElementsByPrice(futuristicWeapons);
                            case "engine":
                                return SelectElementsByPrice(futuristicEngines);
                            default:
                                return null;
                        }
                    default:
                        return null;
                }
            }
            else
            {
                throw new ArgumentNullException("The ship is not selected!");
            }
        }

        private Dictionary<string, int> SelectElementsByPrice(Dictionary<string, int> shipType)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>();

            foreach (var element in shipType)
            {
                if (availableМoney - element.Value >= 0)
                {
                    elements.Add(element.Key, element.Value);
                }
            }
            return new Dictionary<string, int>(elements);
        }
    }
}
