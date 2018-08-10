using SpaceshipBattle.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpaceshipBattle.Core.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteTextCenter(int col, int row, string text)
        {
            Console.SetCursorPosition(col - (text.Length / 2), row);
            Console.Write(text);
        }

        public void WriteMenu(int col, int row, string textMenu)
        {
            Console.SetCursorPosition(col - (textMenu.Length / 2) - 3, row);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(">> " + textMenu + " <<");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void WriteColorTextCenter(string message)
        {
            int positionRow = (Console.WindowHeight / 2) - 5;
            int positionCol = (Console.WindowWidth / 2);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            WriteTextCenter(positionCol, positionRow, message);

            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;

            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}
