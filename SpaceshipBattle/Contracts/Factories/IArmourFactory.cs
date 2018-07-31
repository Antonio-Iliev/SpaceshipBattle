using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts.Factories
{
    public interface IArmourFactory
    {
        IArmour CreatEngine(string model, int points, int price, int weight);
    }
}
