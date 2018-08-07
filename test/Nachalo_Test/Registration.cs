using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Nachalo_Test
{
    public class Registration
    {
        private string userName;
        private List<string> addCommands = new List<string>();
        private int positionYSelect = 0;
        private string[] spaceShipNames = new string[] { "Dross-Mashup Spaceship", "Futuristic Spaceship", };
        private static readonly Registration instace = new Registration();

        private int positionRow;
        private int positionCol;
        private int rowOffset = 5;
        private int colOffset = 0;

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

        public void ChooseName()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset;
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            WriteTextInPosition(this.positionCol, this.positionRow++, "Welcome player 1");
            WriteTextInPosition(this.positionCol, this.positionRow++, "Enter your name:");

            Console.SetCursorPosition(positionCol - 5, positionRow++);
            this.UserName = Console.ReadLine();
        }

        public void WelcomScreen()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset;
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            WriteTextInPosition(this.positionCol, this.positionRow, $"Welcome {this.userName}!");

            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void ChooseSpaceShip()
        {
            this.positionRow = (Console.WindowHeight / 2) - rowOffset;
            this.positionCol = (Console.WindowWidth / 2) - colOffset;

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
                        if (positionYSelect < spaceShipNames.Length - 1)
                        {
                            positionYSelect++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        switch (positionYSelect)
                        {
                            case 0:
                                break;
                            case 1:
                                break;
                            case 2:
                                break;
                            default:
                                break;
                        }
                    }
                }

                WriteTextInPosition(this.positionCol, this.positionRow, "Choose your Spaceship:");

                for (int i = 0; i < spaceShipNames.Length; i++)
                {
                    DrawMenu(positionCol, positionRow + 1 + i, spaceShipNames[i], i);
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

        private void DrawMenu(int col, int row, string textMenu, int menuPosition)
        {

            if (positionYSelect == menuPosition)
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

        public static Registration Instace { get => instace; }
    }
}
