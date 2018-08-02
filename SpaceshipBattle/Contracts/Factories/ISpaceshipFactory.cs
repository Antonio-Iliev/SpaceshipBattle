using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts.Factories
{
   public interface ISpaceshipFactory 
    {
        ISpaceship CreateSpaceship(string model, IEngine engine, IArmour armour, IWeapon weapon, string[] design);
    }
}
