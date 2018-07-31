using SpaceshipBattle.Entities;
using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities
{
    //2 вида кораба - единият с 2 оръжия,  а другият с 1 и с повече health
    public abstract class Spaceship : Item, ISpaceship
    {
        protected Spaceship(string model, int health, int fuel, IArmour armour, IEngine engine, IWeapon weapon)
        {
            base.Model = model;
            this.Health = health;
            this.FuelCapacity = fuel;
            this.Armour = armour;
            this.Engine = engine;
            this.Weapon = weapon;
        }

        public int Health { get; set; } = 100;
        
        public int FuelCapacity { get; set; } // mashUp = 30, futuristic = 25
        public IArmour Armour { get; set; }
        public IEngine Engine { get; set; }
        public IWeapon Weapon { get; set; }

        public int ArmourPoints { get; set; } // = armourCoef; (~50) 
        public int HitPoints { get; set; }  // = weaponsCoef ( ~10)
        public int Speed { get; set; } // = totalWeight/ engineCoef steps (1:3)
        public int PositionY { get; set; }
        public bool isAtShooting { get; set; }
        public int PositionAtTheMomentOfShooting { get; set; }
        public int TotalDist { get; set; } // moveCount * step
        // totalWeight - sum of armour.weight, engine.weight and weapon.weight


        public void Refuel()
        {
            throw new NotImplementedException();
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }

        public void Move(string direction)
        {
            //TotalDist += Speed;
            //FuelCapacity -= Speed;
            throw new NotImplementedException();
        }
    }
}
