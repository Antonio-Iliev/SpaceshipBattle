using SpaceshipBattle.Contracts.Entities.Weapon;
using SpaceshipsBattle.Entities.Weapons;

namespace SpaceshipBattle.Entities.Weapons
{
    public class AreaOfEffectWeapon : WeaponAbstract, IAreaOfEffectWeapon
    {
        protected int spashArea;
        public AreaOfEffectWeapon(string model, int price, int weight, int power, int speed, int clipCapacity, int splashArea) : base(model, price, weight, power, speed, clipCapacity)
        {
            SplashArea = spashArea;
        }

        public int SplashArea { get; protected set; }
        
    }
}
