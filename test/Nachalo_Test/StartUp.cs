using System;

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


            // First Player
            Registration firstPlayer = new Registration();

            firstPlayer.ChooseName();
            firstPlayer.MessageScreen($"Welcome {firstPlayer.UserName}!");
            firstPlayer.ChooseSpaceShip();
            firstPlayer.ChooseComponent();
            firstPlayer.MessageScreen("You are ready!!!");

            // Second Player
            Registration secondPlayer = new Registration();

            secondPlayer.ChooseName();
            secondPlayer.MessageScreen($"Welcome {secondPlayer.UserName}!");
            secondPlayer.ChooseSpaceShip();
            secondPlayer.ChooseComponent();
            secondPlayer.MessageScreen("You are ready!!!");



            Console.WriteLine("First player:");
            Console.WriteLine(firstPlayer.ToString());
            Console.WriteLine("Second player:");
            Console.WriteLine(secondPlayer.ToString());

        }
    }
}
