using System;
using System.Collections.Generic;
using System.Text;

namespace Nachalo_Test
{
    public class Registration
    {
        private string userName;
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
            this.positionRow = (Console.WindowHeight / 2) - rowOffset;
            this.positionCol = (Console.WindowWidth / 2) - colOffset;
        }

        private void WriteTextInPosition(int col, int row, string text)
        {
            Console.SetCursorPosition(col - (text.Length / 2), row);
            Console.Write(text);
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

            WriteTextInPosition(this.positionCol, this.positionRow, "Choose your Spaceship:");

            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
        }

        public static Registration Instace { get => instace; }
    }
}
