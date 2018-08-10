using SpaceshipBattle.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
