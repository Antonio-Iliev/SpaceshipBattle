using SpaceshipsBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Entities.Players
{
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public int Money { get; set; }

        public ISpaceship Spaceship { get; set; }
    }
}
