using SpaceshipBattle.Contracts.Entities;
using SpaceshipBattle.Entities;
using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities
{
    //2 вида кораба - единият с 2 оръжия,  а другият с 1 и с повече health
    public abstract class Spaceship : ISpaceship
    {
        private const int MinPriceValue = 1000;
        private const int MaxPriceValue = 10000;
        private string[] design;

        public Spaceship(IEngine engine, IArmour armour, IWeapon weapon, string[] design)
        {
            this.Engine = engine;
            this.Armour = armour;
            this.Weapon = weapon;
            this.Design = design;
        }

        public int Health { get; set; } = 100;

        public string Model => this.GetType().Name;

        public int Price
        {
            get => this.Engine.Price + this.Armour.Price + this.Weapon.Price;
            protected set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentOutOfRangeException($"The price of {this.GetType().Name} cannot be less than {MinPriceValue} or more than {MaxPriceValue}.");
                }
            }
        }

        public int Weight => this.Engine.Weight + this.Armour.Weight + this.Weapon.Weight;

        public virtual int FuelCapacity { get; private set; }

        public IEngine Engine { get; set; }

        public IArmour Armour { get; set; }

        public IWeapon Weapon { get; set; }

        public string[] Design
        {
            get => this.design;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Design cannot be null");
                }
                this.design = value;
            }
        }

        //TODO
        public int Speed => this.Engine.EngineEfficiencyCoef;

        public int PositionY { get; set; }

        public bool IsAtShooting { get; set; } = false;

        public int TotalDist { get; set; } = 0;

        public void Refuel()
        {
            this.TotalDist = this.FuelCapacity;
        }

        public void Shoot(string side)
        {
            if (this.IsAtShooting == false)
            {
                this.Weapon.Bullet.PositionY = this.PositionY;
                this.IsAtShooting = true;

                if (side == "left")
                {
                    this.Weapon.Bullet.PositionX = 1;
                }
                else
                {
                    this.Weapon.Bullet.PositionX = Console.WindowWidth - 1;
                }
            }
        }

        public void Move(string direction)
        {
            if (direction == "down")
            {
                if (this.PositionY + this.Speed < Console.WindowHeight - 2)
                {
                    this.PositionY++;
                    this.TotalDist += this.Speed;

                    if (this.TotalDist >= FuelCapacity)
                    {
                        Refuel();
                    }
                }
            }
            //up
            else
            {
                if (this.PositionY + this.Speed > 3)
                {
                    this.PositionY--;
                    this.TotalDist += this.Speed;

                    if (this.TotalDist >= FuelCapacity)
                    {
                        Refuel();
                    }
                }
            }
        }

        public void TakeDamageToPlayer(IPlayer player)
        {
            player.Spaceship.Health -= this.Weapon.Power;
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
