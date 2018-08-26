using System;

namespace SpaceshipBattle.Contracts.Providers
{
    public interface IReader
    {
        string ReadLine();
        ConsoleKeyInfo ReadKey();
        bool KeyAvailable();
    }
}