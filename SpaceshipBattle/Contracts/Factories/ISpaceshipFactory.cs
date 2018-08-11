using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts.Factories
{
   public interface ISpaceshipFactory 
    {
        ISpaceship CreateSpaceship(string model, ISpaceshipEngine engine, IArmour armour, IWeapon weapon);
    }
}
