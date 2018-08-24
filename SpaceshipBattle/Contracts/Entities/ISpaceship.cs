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

        void ShootFromLeftSide();

        void ShootFromRightSide();

        void Refuel();

        void MoveUp();

        void MoveDown();
        
        void TakeDamageToPlayer(IPlayer player, int damage);

        string Model { get; }

       //string[] Design { get; }
    }
}
