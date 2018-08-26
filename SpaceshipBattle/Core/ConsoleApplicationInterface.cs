using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core
{
    public class ConsoleApplicationInterface : IApplicationInterface
    {
        public void SetGameDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize(120, 35);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
    }
}
