using SpaceshipBattle.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts
{
    public interface ISpaceShip
    {
        int Health { get; set; }

        int TotalDist { get; set; }

        int FuelCapacity { get; }

        int Speed { get; }

        int PositionY { get; set; }

        bool IsAtShooting { get; set; }

        ISpaceshipEngine Engine { get; }

        IWeapon Weapon { get; }

        IArmour Armour { get; }

        void Refuel();
        
        int TakeDamageToPlayer(ISpaceShip player, int damage);

        string Model { get; }

        int Price { get; }

        int Weight { get; }
       //string[] Design { get; }
    }
}
