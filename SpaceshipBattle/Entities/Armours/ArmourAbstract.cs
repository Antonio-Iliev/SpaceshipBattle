using SpaceshipBattle.Entities;
using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipsBattle.Contracts;
using System;

namespace SpaceshipsBattle.Entities.Armour
{
    public abstract class ArmourAbstract : Item, IArmour
    {
        private int points;
        private string model;
        private int price;
        private int weight;
        private ArmourType armourType;

        public ArmourAbstract(string model, int price, int weight, int points, ArmourType armourType)
            : base(model, price, weight)
        {
            this.Points = points;
            this.ArmourType = armourType;
        }

        public virtual int Points
        {
            get { return this.points; }
            private set
            {
                if (value < 10 || value > 250)
                {
                    throw new ArgumentOutOfRangeException("Armour must be between 10 and 250 pints ");
                }
                this.points = value;
            }
        }

        public ArmourType ArmourType { get => this.armourType;  set => this.armourType = value; }

        public override string ToString()
        {
            return base.ToString() + $"Armour points: {this.points}" +
                $"Armour type: {this.armourType}";
        }
    }
}
