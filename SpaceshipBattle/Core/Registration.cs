using SpaceshipBattle.Contracts.Providers;
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

        private readonly Dictionary<string, int> weapons = new Dictionary<string, int>
                        { { "AK47", 2000 }, {"Cannon", 3000 }, {"Laser", 2500 }, {"Plasma Weapon", 4000 } };

        private readonly Dictionary<string, int> engines = new Dictionary<string, int>
        { { "Trabant Motor", 1000 }, {"VW 1.9 TDI", 1500 }, {"Ferrari V12 GT", 3500 }, {"Bugatti W16", 4000 },
            { "H2O Motor", 1000 }, {"Ion X3", 2000 }, {"Vasimir Plasma Engine", 3500 } };

        private readonly Dictionary<string, int> armors = new Dictionary<string, int>
        {{ "Recycled Paper", 1000 }, {"Brick cage",1500 }, {"Aerogel cover",2000 }, {"Fullerenes Armour", 3500 },
            { "Switz Armour", 2500 }, {"Plasma Field", 1800 }, {"Anti Matter Fields", 5000 } };

        private Dictionary<string, string> parametersForPlayer = new Dictionary<string, string>();

        public Registration(IReader reader, IWriter writer)
        {
            this.Reader = reader;
            this.Writer = writer;
        }

        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }

        public Dictionary<string, string> ParametersForPlayer { get => new Dictionary<string, string>(this.parametersForPlayer); }

        public void ChooseName()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset;
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            Writer.WriteTextCenter(this.positionCol, this.positionRow++, $"Welcome to space fight arena!");
            Writer.WriteTextCenter(this.positionCol, this.positionRow++, "Enter your name:");

            Console.SetCursorPosition(positionCol - 10, positionRow + 1);
            Writer.Write(">>>> ");

            string nameOfPlayer = Reader.ReadLine();
            bool isValid = false;
            while (!isValid)
            {
                if (String.IsNullOrEmpty(nameOfPlayer) || String.IsNullOrWhiteSpace(nameOfPlayer)
                    || nameOfPlayer.Length < 3 || nameOfPlayer.Length > 35)
                {
                    Console.SetCursorPosition(positionCol - 5, positionRow + 1);
                    Writer.Write("   ");
                    Console.SetCursorPosition(positionCol - 5, positionRow + 2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Writer.Write("Name must be between 3 and 35 characters");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(positionCol - 5, positionRow + 1);
                    nameOfPlayer = Reader.ReadLine();
                }
                else
                {
                    parametersForPlayer.Add("name", nameOfPlayer);
                    isValid = true;
                }
            }
            Console.Clear();
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
                    if (availableМoney - weapons.Values.ElementAt(i) >= 0)
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
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private string ChooseEngine()
        {
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
                    if (availableМoney - engines.Values.ElementAt(i) >= 0)
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
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private string ChooseArmour()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (armors.Count / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            int lengthOfElements = armors.Count;
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
                        availableМoney -= armors.Values.ElementAt(focusPosition);
                        return armors.Keys.ElementAt(focusPosition);
                    }
                }

                Writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your impenetrable skin (armour):");
                Writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "___________________________");

                int elementRow = 1;
                for (int i = 0; i < lengthOfElements; i++)
                {
                    if (availableМoney - armors.Values.ElementAt(i) >= 0)
                    {
                        string str = armors.Keys.ElementAt(i) + "  - cost: " + armors.Values.ElementAt(i) + " GC";
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
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Thread.Sleep(100);
                Console.Clear();
            }
        }

    }
}
