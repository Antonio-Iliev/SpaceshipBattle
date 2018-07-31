using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Armours.FuturisticArmours
{
    class AerogelArmour : IArmour
    {
        private readonly string model = "Aerogel Armour";
        private readonly int points = 220;
        private readonly int price = 40;
        private readonly int weight = 20;

        public string Model => this.model;

        public int Points => this.points;

        public int Price => this.price;

        public int Weight => this.weight;
    }
}
