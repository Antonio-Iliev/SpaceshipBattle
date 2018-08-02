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

        int Speed { get; }
        //TODO
        int PositionY { get; set; }
        //TODO
        bool IsAtShooting { get; set; }

        //TODO
        int PositionAtTheMomentOfShooting { get; set; }

        IEngine Engine { get; }

        IWeapon Weapon { get; }

        IArmour Armour { get; }

        void Shoot();

        void Refuel();

        void Move(string direction);
    }
}
