using SpaceshipBattle.Contracts.Entities;
using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipsBattle.Entities.Armour;
using System;

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

        public int ArmourCoefficient { get => this.Points + this.reflection - this.refraction; }
    }
}
