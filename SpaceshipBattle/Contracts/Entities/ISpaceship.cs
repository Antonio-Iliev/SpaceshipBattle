using SpaceshipBattle.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Contracts
{
    public interface ISpaceship
    {
        int Health { get; set; }

        int TotalDist { get; }

        int FuelCapacity { get; }

        int Speed { get; }

        int PositionY { get; set; }

        bool IsAtShooting { get; set; }

        ISpaceshipEngine Engine { get; }

        IWeapon Weapon { get; }

        IArmour Armour { get; }

        void Shoot(string side);

        void Refuel();

        void Move(string direction);

        void TakeDamageToPlayer(IPlayer player);

        string Model { get; }

       //string[] Design { get; }
    }
}
