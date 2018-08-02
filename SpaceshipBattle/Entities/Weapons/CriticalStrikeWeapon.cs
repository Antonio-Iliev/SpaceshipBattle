using SpaceshipBattle.Contracts.Entities.Weapon;
using SpaceshipBattle.Entities.Weapons;
using System;

namespace SpaceshipBattle.Entities.Weapons
{
    class CriticalStrikeWeapon : WeaponAbstract, ICriticalStrikeWeapon
    {
        protected int criticalStrikeChance;
        public CriticalStrikeWeapon(string model, int price, int weight, int power, int speed, int clipCapacity, int criticalStrikeChance) : base(model, price, weight, power, speed, clipCapacity)
        {
            CriticalStrikeChance = criticalStrikeChance;
        }
        public int CriticalStrikeChance
        { get; protected set; }
        
    }
}
