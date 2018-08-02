using SpaceshipBattle.Contracts.Entities;
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
        //TODO
        protected Spaceship() : base("asf",12, 2)
        {

        }

        public int Health => 100;

        public override string Model => this.GetType().Name;

        public override int Price => this.Engine.Price + this.Armour.Price + this.Weapon.Price;

        public override int Weight => this.Engine.Weight + this.Armour.Weight + this.Weapon.Weight;

        public int FuelCapacity { get; set; } // mashUp = 30, futuristic = 25

        public IArmour Armour { get; set; }

        public IEngine Engine { get; set; }

        public IWeapon Weapon { get; set; }

        //TODO
        public int Speed => this.Engine.EngineEfficiencyCoef;

        public int PositionY { get; set; }

        public bool isAtShooting { get; set; } = false;

        public int PositionAtTheMomentOfShooting { get; set; }

        public int TotalDist { get; set; } = 0;

        //public int ArmourPoints { get; set; } // = armourCoef; (~50) 
        //public int HitPoints { get; set; }  // = weaponsCoef ( ~10)

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


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Engine: {this.Engine.Model}");
            sb.AppendLine($"Armour: {this.Armour.Model}");
            sb.AppendLine($"Weapon: {this.Weapon.Model}");

            return base.ToString();
        }
    }
}
