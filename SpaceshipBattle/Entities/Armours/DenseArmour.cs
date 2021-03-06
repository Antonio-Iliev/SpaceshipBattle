﻿using SpaceshipBattle.Contracts.Entities;
using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipBattle.Entities.Armour;
using System;
using System.Text;

namespace SpaceshipBattle.Entities.Armours
{
    class DenseArmour : ArmourAbstract, IDenseArmour
    {
        //the ability of the armor to resist indentation
        private int hardness;
        //the ability of the armor to absorb energy before fracturing
        private int toughness;

        public DenseArmour(string model, int price, int weight, int points, int hardness, int toughness, ArmourType armourType)
            : base(model, price, weight, points, armourType)
        {
            this.Hardness = hardness;
            this.Toughness = toughness;
            this.ArmourCoefficient = this.Points + this.Hardness + this.Toughness;
        }

        public int Hardness
        {
            get => this.hardness;
            private set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Hardness must be between 0 and 10 pints.");
                }
                this.hardness = value;
            }
        }
        public int Toughness
        {
            get => this.toughness;
            private set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentException("Toughness must be between 0 and 5 pints.");
                }
                this.toughness = value;
            }
        }

        public override int ArmourCoefficient { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Hardness: {this.hardness}");
            sb.AppendLine($"Toughness: {this.toughness}");
            return sb.ToString();
        }
    }
}
