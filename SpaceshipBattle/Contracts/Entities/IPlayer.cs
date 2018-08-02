using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts
{
    public interface IPlayer
    {
        string Name { get; }

        ISpaceship Spaceship { get; }

        int Money { get; }

    }
}
