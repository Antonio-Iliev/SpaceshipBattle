using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts.Providers
{
    public interface IConsoleReader : IReader
    {
        ConsoleKeyInfo ReadKey();
    }
}
