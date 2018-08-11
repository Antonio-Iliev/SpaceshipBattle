using SpaceshipBattle.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SpaceshipBattle.Core
{
    public class Registration
    {
        private int positionRow;
        private int positionCol;
        private int rowOffset = 5;
        private int colOffset = 0;

        private readonly string[] spaceshipNames = new string[] { "Dross-Mashup Spaceship", "Futuristic Spaceship" };

        private readonly string[] componentsInSpaceship = new string[] { "Weapon", "Engine", "Armour" };

        private readonly string[] weapons = new string[] { "AK47", "Cannon", "Laser", "Plasma Weapon", };

        private readonly string[] engines = new string[] { "Trabant Motor", "VW 1.9 TDI", "Ferrari V12 GT", "Bugatti W16",
                                                             "H2O Motor", "Ion X3", "Vasimir Plasma Engine" };

        private readonly string[] armors = new string[] { "Recycled Paper", "Brick cage", "Aerogel cover",
                                                            "Fullerenes Armour", "Switz Armour", "Plasma Field", "Anti Matter Fields" };

        private Dictionary<string, string> parametersForPlayer = new Dictionary<string, string>();

        public Registration(IReader reader, IWriter writer)
        {
            this.Reader = reader;
            this.Writer = writer;
        }

        private IReader Reader { get; set; }
        private IWriter Writer { get; set; }

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
                Thread.Sleep(30);
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
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (weapons.Length / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            int lengthOfElements = weapons.Length;
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
                        return weapons[focusPosition];
                    }
                }

                Writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your weapon of destruction:");
                Writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "_________________________");

                for (int i = 0; i < lengthOfElements; i++)
                {
                    if (focusPosition == i)
                    {
                        Writer.WriteMenu(positionCol, positionRow + 1 + i, weapons[i]);
                    }
                    else
                    {
                        Writer.WriteTextCenter(positionCol, positionRow + 1 + i, weapons[i]);
                    }

                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private string ChooseEngine()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (engines.Length / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            int lengthOfElements = engines.Length;
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
                        return engines[focusPosition];
                    }
                }

                Writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your flying power (engine):");
                Writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "___________________________");

                for (int i = 0; i < lengthOfElements; i++)
                {
                    if (focusPosition == i)
                    {
                        Writer.WriteMenu(positionCol, positionRow + 1 + i, engines[i]);
                    }
                    else
                    {
                        Writer.WriteTextCenter(positionCol, positionRow + 1 + i, engines[i]);
                    }
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private string ChooseArmour()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (armors.Length / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            int lengthOfElements = armors.Length;
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
                        return armors[focusPosition];
                    }
                }

                Writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your impenetrable skin (armour):");
                Writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "___________________________");

                for (int i = 0; i < lengthOfElements; i++)
                {
                    if (focusPosition == i)
                    {
                        Writer.WriteMenu(positionCol, positionRow + 1 + i, armors[i]);
                    }
                    else
                    {
                        Writer.WriteTextCenter(positionCol, positionRow + 1 + i, armors[i]);
                    }
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Thread.Sleep(100);
                Console.Clear();
            }
        }

    }
}
