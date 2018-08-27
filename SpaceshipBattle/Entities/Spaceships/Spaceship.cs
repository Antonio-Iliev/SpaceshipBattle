using SpaceshipBattle.Contracts.Entities;
using SpaceshipBattle.Entities;
using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities
{
    public abstract class Spaceship : ISpaceShip
    {
        private const int MinPriceValue = 1000;
        private const int MaxPriceValue = 10000;

        private string model;

        public Spaceship(ISpaceshipEngine engine, IArmour armour, IWeapon weapon, string model)
        {
            this.Engine = engine;
            this.Armour = armour;
            this.Weapon = weapon;
            this.Model = model;
        }
         
        public int Health { get; set; } = 100;

        public string Model
        {
            get => this.model;
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Spaceship name cannot be null or empty!");
                }
                this.model = value;
            }
        }

        public int Price
        {
            get => this.Engine.Price + this.Armour.Price + this.Weapon.Price;
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentOutOfRangeException($"The price of {this.GetType().Name} cannot be less than {MinPriceValue} or more than {MaxPriceValue}.");
                }
            }
        }

        public int Weight => this.Engine.Weight + this.Armour.Weight + this.Weapon.Weight;

        public virtual int FuelCapacity { get; protected set; }

        public ISpaceshipEngine Engine { get; private set; }

        public IArmour Armour { get; private set; }

        public IWeapon Weapon { get; private set; }

        public int Speed => Math.Max(1, (int)Math.Round(this.Engine.EngineEfficiencyCoef - this.Weight / 2000d));

        public int PositionY { get; set; }

        public bool IsAtShooting { get; set; } = false;

        public int TotalDist { get; set; } = 0;

        public void Refuel()
        {
            this.TotalDist = this.FuelCapacity;
        }
                       
        public int TakeDamageToPlayer(ISpaceShip spaceship, int damage)
        {            
            if (spaceship.Armour.ArmourCoefficient > 0)
            {
                spaceship.Armour.ArmourCoefficient -= damage;

                if (spaceship.Armour.ArmourCoefficient < 0)
                {
                    spaceship.Health -= spaceship.Armour.ArmourCoefficient;
                    spaceship.Armour.ArmourCoefficient = 0;
                }
            }
            else
            {
                spaceship.Health -= damage;
            }

            return spaceship.Armour.ArmourCoefficient;
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
