using SpaceshipBattle.Contracts.Entities;
using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipBattle.Entities.Armour;
using System;
using System.Text;

namespace SpaceshipBattle.Entities.Armours
{
    public class ProtectiveFields : ArmourAbstract, IProtectiveFields
    {
        private int reflection;
        private int refraction;

        public ProtectiveFields(string model, int price, int weight, int points, int reflection, int refraction, ArmourType armourType)
            : base(model, price, weight, points, armourType)
        {
            this.Reflection = reflection;
            this.Refraction = refraction;
            this.ArmourCoefficient = this.Points + this.Reflection - this.Refraction;
        }

        public int Reflection
        {
            get => this.reflection;
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Reflection must be between 0 and 10 pints.");
                }
                this.reflection = value;
            }
        }
        public int Refraction
        {
            get => this.refraction;
            set
            {
                if (value < 0 || value > 15)
                {
                    throw new ArgumentOutOfRangeException("Refraction must be between 0 and 15 pints.");
                }
                this.refraction = value;
            }
        }

        public override int ArmourCoefficient { get => this.Points + this.reflection - this.refraction; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Reflection coefficient: {this.reflection}");
            sb.AppendLine($"Refraction coefficient: {this.refraction}");
            return base.ToString();
        }
    }
}
