using SpaceshipsBattle.Contracts;
using System;

namespace SpaceshipBattle.Entities.Armours
{
    public class Armour : IArmour
    {
        private IArmour armour;

        public Armour(IArmour armour)
        {
            this.armour = armour;
        }

        public string Model => armour.Model;

        public int Points => armour.Points;

        public int Price => armour.Price;

        public int Weight => armour.Weight;
    }
}
