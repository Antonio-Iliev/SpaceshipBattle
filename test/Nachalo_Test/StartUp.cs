using System;
using System.Threading;

namespace Nachalo_Test
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize(120, 35);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            ////Ekran 1
            //Registration.Instace.ChooseName();
            //Console.Clear();

            ////Ekran 2
            //Registration.Instace.WelcomScreen();
            //Thread.Sleep(3000);
            //Console.Clear();

            Registration.Instace.ChooseSpaceShip();
        }
    }
}
