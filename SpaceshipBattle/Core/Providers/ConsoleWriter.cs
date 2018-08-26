using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core.Common;
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

        public void Write(char symbol)
        {
            Console.Write(symbol);
        }

        public void WriteLine(char symbol)
        {
            Console.WriteLine(symbol);
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
            message = message.PadLeft(message.Length + 1);
            message = message.PadRight(message.Length + 1);
            int positionRow = (Console.WindowHeight / 2) - 5;
            int positionCol = (Console.WindowWidth / 2);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            WriteTextCenter(positionCol, positionRow++, new string(' ', message.Length));
            WriteTextCenter(positionCol, positionRow++, message);
            WriteTextCenter(positionCol, positionRow++, new string(' ', message.Length));

            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;

            Thread.Sleep(2000);
            Console.Clear();
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void WriteTextAtPosition(int col, int row, string text)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(text);
        }

        public void SetTextColor(Colors color)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.ToString());
        }

        public void SetWindowSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }

        public void SetCursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public bool KeyAvailable()
        {
            return Console.KeyAvailable;
        }

        //TODO: Ask trainers
        public int GetWindowHeight()
        {
            return Console.WindowHeight;
        }

        public int GetWindowWidth()
        {
            return Console.WindowWidth;
        }


    }
}
