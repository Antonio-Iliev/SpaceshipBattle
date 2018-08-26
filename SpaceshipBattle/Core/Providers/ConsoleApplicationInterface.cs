using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

        public int WindowHeight { get => Console.WindowHeight; }
        public int WindowWidth { get => Console.WindowWidth; }

        public void FreezeScreen(int inMiliseconds)
        {
            Thread.Sleep(inMiliseconds);
        }
    }
}
