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
    }
}
