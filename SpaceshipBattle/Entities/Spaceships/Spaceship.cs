using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities
{
    //2 вида кораба - единият с 2 оръжия,  а другият с 1 и с повече health
    public abstract class Spaceship : ISpaceship
    {
        protected Spaceship(string model, int health, int fuel, IArmour armour, IEngine engine, IWeapon weapon)
        {
            this.Model = model;
            this.Health = health;
            this.Fuel = fuel;
            this.Armour = armour;
            this.Engine = engine;
            this.Weapon = weapon;
        }

        public string Model { get; set; }
        public int Health { get; set; }
        
        public int Fuel { get; set; }
        public IArmour Armour { get; set; }
        public IEngine Engine { get; set; }
        public IWeapon Weapon { get; set; }


        public int Price { get; set; }
        public int Speed { get; set; }
        public int PositionY { get; set; }
        public bool isAtShooting { get; set; }
        public int PositionAtTheMomentOfShooting { get; set; }
        public int Weight { get; set; }
        public int TotalDist { get; set; }

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

        }
    }
}
