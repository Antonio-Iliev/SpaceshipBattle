using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Contracts
{
    public interface ISpaceship : IItem
    {
        int Health { get; }

        int TotalDist { get; }

        int FuelCapacity { get; }

        int PositionY { get; }

        bool isAtShooting { get; }

        int PositionAtTheMomentOfShooting { get; }

        IEngine Engine { get; }

        IWeapon Weapon { get; }

        IArmour Armour { get; }

        void Shoot();

        void Refuel();

        void Move(string direction);
    }
}
