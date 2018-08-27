using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Players
{
    public class Player : IPlayer
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 15;
        
        private string name;

        public Player(string name, ISpaceShip spaceship)
        {
            this.Name = name;
            this.Spaceship = spaceship;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException($"The player name cannot be less than {MinNameLength} or more than {MaxNameLength} symbols long.");
                }
                this.name = value;
            }
        }
        public int Money { get; set; } = 10000;

        public ISpaceShip Spaceship { get; set; }
    }
}
