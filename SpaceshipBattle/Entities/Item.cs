using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities
{
    public abstract class Item : IItem
    {
        private const int MinModelLength = 2;
        private const int MaxModelLength = 15;
        private const int MinPriceValue = 1000;
        private const int MaxPriceValue = 5000;
        private const int MinWeightValue = 0;
        private const int MaxWeightValue = 1000;

        private string model;
        private int price;
        private int weight;

        protected Item(string model, int price, int weight)
        {
            this.Model = model;
            this.Price = price;
            this.Weight = weight;
        }

        public virtual string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"The model of {this.GetType().Name} cannot be null.");
                }
                if (value.Length < MinModelLength || value.Length > MaxModelLength)
                {
                    throw new ArgumentOutOfRangeException($"The model's length of {this.GetType().Name} cannot be less than {MinModelLength} or more than {MaxModelLength} symbols long.");
                }
                this.model = value;
            }
        }

        public virtual int Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value < MinPriceValue || value > MaxPriceValue)
                {
                    throw new ArgumentOutOfRangeException($"The price of {this.GetType().Name} cannot be less than {MinPriceValue} or more than {MaxPriceValue}.");
                }
                this.price = value;
            }
        }

        public virtual int Weight
        {
            get
            {
                return this.weight;
            }
            protected set
            {
                if (value < MinWeightValue || value > MaxWeightValue)
                {
                    throw new ArgumentOutOfRangeException($"The weight of {this.GetType().Name} cannot be less than {MinWeightValue} or more than {MaxWeightValue}.");
                }
                this.weight = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"---{this.GetType().Name}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Price: {this.Price}$");
            sb.Append($"Weight: {this.Weight}kg");

            return sb.ToString();
        }
    }
}
