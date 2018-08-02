using SpaceshipBattle.Entities;
using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipBattle.Contracts;
using System;
using System.Text;

namespace SpaceshipBattle.Entities.Armour
{
    public abstract class ArmourAbstract : Item, IArmour
    {
        private int points;
        private string model;
        private int price;
        private int weight;

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
                    throw new ArgumentOutOfRangeException("Armour must be between 10 and 250 pints.");
                }
                this.points = value;
            }
        }

        public ArmourType ArmourType { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Defense points: {this.points}");
            sb.AppendLine($"Armour type: {this.ArmourType} -----");
            return sb.ToString();
        }
    }
}
