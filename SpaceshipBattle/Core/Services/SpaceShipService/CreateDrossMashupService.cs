using System;
using System.Collections.Generic;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Spaceships;

namespace SpaceshipBattle.Core.Services.SpaceShipService
{
    public class CreateDrossMashupService : ISpaceShipService
    {
        public ISpaceShip CreateSpaceship(string model, ISpaceshipEngine engine, IArmour armour, IWeapon weapon)
        {
            return new DrossMashupSpaceship(engine, armour, weapon, model);
        }

    }
}
