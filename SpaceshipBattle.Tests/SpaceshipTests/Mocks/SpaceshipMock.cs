using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.SpaceshipTests.Mocks
{
    internal class SpaceshipMock : Spaceship
    {
        public SpaceshipMock(ISpaceshipEngine engine, IArmour armour, IWeapon weapon, string model) : base(engine, armour, weapon, model)
        {
        }

    }
}
