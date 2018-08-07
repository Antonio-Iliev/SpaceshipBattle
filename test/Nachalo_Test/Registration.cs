using System;
using System.Collections.Generic;
using System.Threading;

namespace Nachalo_Test
{
    public class Registration
    {

        private int positionRow;
        private int positionCol;
        private int rowOffset = 5;
        private int colOffset = 0;
        private string userName;
        private List<string> addCommands = new List<string>();
        private int positionYSelect;

        private readonly string[] spaceshipNames = new string[] { "Dross-Mashup Spaceship", "Futuristic Spaceship", };
        private readonly string[] componentSpaceship = new string[] { "Weapon", "Engine", "Armour" };
        private readonly string[] weapons = new string[] { "AK47", "Cannon", "Laser", "Plasma Weapon", };
        private readonly string[] engines = new string[] { "Trabant", "TDI", "Ferrari", "Bugatti", "H2O", "Ion", "Plasma" };
        private readonly string[] armors = new string[] { "Recycled Paper", "Brick cage", "Aerogel cover",
                                                            "Fullerenes Armour", "Switz Armour", "Plasma Field", "Anti Matter Fields" };
        private string selectedWeapon;
        private string selectedEngine;
        private string selectedArmour;



        public string UserName
        {
            get => this.userName;
            private set
            {
                if (false)
                {
                    // TODO proverka
                }
                this.userName = value;
            }
        }

        public List<string> AddCommands { get => new List<string>(this.addCommands); }

        public void ChooseName()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset;
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            WriteTextInPosition(this.positionCol, this.positionRow++, $"Welcome to space fight arena!");
            WriteTextInPosition(this.positionCol, this.positionRow++, "Enter your name:");

            Console.SetCursorPosition(positionCol - 10, positionRow + 1);
            Console.Write(">>>> ");
            this.UserName = Console.ReadLine();
            Console.Clear();
        }

        public void MessageScreen(string message)
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset;
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            WriteTextInPosition(this.positionCol, this.positionRow, message);

            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;

            Thread.Sleep(3000);
            Console.Clear();
        }

        public void ChooseSpaceShip()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (spaceshipNames.Length / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;
            positionYSelect = 0;

            int lengthOfElements = spaceshipNames.Length;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (positionYSelect > 0)
                        {
                            positionYSelect--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (positionYSelect < lengthOfElements - 1)
                        {
                            positionYSelect++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        this.addCommands.Add(this.spaceshipNames[positionYSelect]);
                        Console.Clear();
                        return;
                    }
                }

                WriteTextInPosition(this.positionCol, this.positionRow - 2, "Choose your Spaceship:");
                WriteTextInPosition(this.positionCol, this.positionRow - 1, "__________________");

                for (int i = 0; i < lengthOfElements; i++)
                {
                    DrawMenu(positionCol, positionRow + 1 + i, spaceshipNames[i], i);
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

                Thread.Sleep(100);
                Console.Clear();
            }

        }

        public void ChooseComponent()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (spaceshipNames.Length / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;
            positionYSelect = 0;

            List<string> compList = new List<string>(componentSpaceship);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (positionYSelect > 0)
                        {
                            positionYSelect--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (positionYSelect < compList.Count - 1)
                        {
                            positionYSelect++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        switch (compList[positionYSelect].ToLower())
                        {
                            case "weapon":
                                compList.Remove(compList[positionYSelect]);
                                ChooseWeapon();
                                break;

                            case "engine":
                                compList.Remove(compList[positionYSelect]);
                                ChooseEngine();
                                break;
                            case "armour":
                                compList.Remove(compList[positionYSelect]);
                                ChooseArmour();
                                break;

                            default:
                                break;
                        }
                    }
                }

                if (compList.Count == 0)
                {
                    addCommands.Add(selectedWeapon);
                    addCommands.Add(selectedEngine);
                    addCommands.Add(selectedArmour);
                    Console.Clear();
                    return;
                }
                else
                {
                    WriteTextInPosition(this.positionCol, this.positionRow - 2, "Choose component for your ship:");
                    WriteTextInPosition(this.positionCol, this.positionRow - 1, "_____________________");

                    for (int i = 0; i < compList.Count; i++)
                    {
                        DrawMenu(positionCol, positionRow + 1 + i, compList[i], i);
                    }
                    Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                    Thread.Sleep(100);
                    Console.Clear();
                }
            }
        }

        public void ChooseWeapon()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (spaceshipNames.Length / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            int lengthOfElements = weapons.Length;
            positionYSelect = 0;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (positionYSelect > 0)
                        {
                            positionYSelect--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (positionYSelect < lengthOfElements - 1)
                        {
                            positionYSelect++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        selectedWeapon = weapons[positionYSelect];
                        positionYSelect = 0;
                        return;
                    }
                }

                WriteTextInPosition(this.positionCol, this.positionRow - 2, "Choose your weapon of destruction:");
                WriteTextInPosition(this.positionCol, this.positionRow - 1, "_________________________");

                for (int i = 0; i < lengthOfElements; i++)
                {
                    DrawMenu(positionCol, positionRow + 1 + i, weapons[i], i);
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

                Thread.Sleep(100);
                Console.Clear();
            }

        }

        public void ChooseEngine()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (spaceshipNames.Length / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            int lengthOfElements = engines.Length;
            positionYSelect = 0;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (positionYSelect > 0)
                        {
                            positionYSelect--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (positionYSelect < lengthOfElements - 1)
                        {
                            positionYSelect++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        selectedEngine = engines[positionYSelect];
                        positionYSelect = 0;
                        return;
                    }
                }

                WriteTextInPosition(this.positionCol, this.positionRow - 2, "Choose your flying power (engine):");
                WriteTextInPosition(this.positionCol, this.positionRow - 1, "___________________________");

                for (int i = 0; i < lengthOfElements; i++)
                {
                    DrawMenu(positionCol, positionRow + 1 + i, engines[i], i);
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

                Thread.Sleep(100);
                Console.Clear();
            }

        }

        public void ChooseArmour()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset - (spaceshipNames.Length / 2);
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            int lengthOfElements = armors.Length;
            positionYSelect = 0;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (positionYSelect > 0)
                        {
                            positionYSelect--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (positionYSelect < lengthOfElements - 1)
                        {
                            positionYSelect++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        selectedArmour = armors[positionYSelect];
                        positionYSelect = 0;
                        return;
                    }
                }

                WriteTextInPosition(this.positionCol, this.positionRow - 2, "Choose your impenetrable skin (armour):");
                WriteTextInPosition(this.positionCol, this.positionRow - 1, "___________________________");

                for (int i = 0; i < lengthOfElements; i++)
                {
                    DrawMenu(positionCol, positionRow + 1 + i, armors[i], i);
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

                Thread.Sleep(100);
                Console.Clear();
            }

        }

        private void WriteTextInPosition(int col, int row, string text)
        {
            Console.SetCursorPosition(col - (text.Length / 2), row);
            Console.Write(text);
        }

        private void DrawMenu(int col, int row, string textMenu, int linePosition)
        {

            if (positionYSelect == linePosition)
            {
                Console.SetCursorPosition(col - (textMenu.Length / 2) - 3, row);

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;

                Console.Write(">> " + textMenu + " <<");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.SetCursorPosition(col - (textMenu.Length / 2), row);
                Console.Write(textMenu);
            }
        }

        public static Registration Instace { get => new Registration(); }

        public override string ToString()
        {
            return $">>>>>. {this.UserName} .<<<<<\r\n" +
                $"Spaceship: {this.addCommands[0]}\r\n" +
                $"Component of the ship is:\r\n-----------\r\n" +
                $"Weapon: {this.addCommands[1]}\r\n" +
                $"Engine: {this.addCommands[2]}\r\n" +
                $"Armour: {this.addCommands[3]}\r\n";
        }
    }
}
