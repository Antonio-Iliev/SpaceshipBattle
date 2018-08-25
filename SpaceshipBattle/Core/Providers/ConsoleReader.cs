using SpaceshipBattle.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        //TODO ?????
        public ConsoleKeyInfo ReadKey()
        {
           return Console.ReadKey();

        }
    }
}
