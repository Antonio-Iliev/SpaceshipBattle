using SpaceshipBattle.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Contracts
{
    public interface ISpaceship
    {
        int Health { get; set; }

        int TotalDist { get; }

        int FuelCapacity { get; }

        int Speed { get; }
        
        int PositionY { get; set; }
        
        bool IsAtShooting { get; set; }

        //TODO
        int PositionAtTheMomentOfShooting { get; set; }

        IEngine Engine { get; }

        IWeapon Weapon { get; }

        IArmour Armour { get; }

        void Shoot(string side);

        void Refuel();

        void Move(string direction);

        void TakeDamage(int hitPoints);
    }
}
