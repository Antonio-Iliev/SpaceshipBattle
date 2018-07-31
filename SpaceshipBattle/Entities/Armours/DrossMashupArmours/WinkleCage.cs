using SpaceshipsBattle.Contracts;
using SpaceshipsBattle.Entities.Armour;

namespace SpaceshipBattle.Entities.Armours
{
    class WinkleCage : IArmour
    {
        private readonly string model = "Winkle cage";
        private readonly int points = 250;
        private readonly int price = 60;
        private readonly int weight = 120;

        public string Model => this.model;

        public int Points => this.points;

        public int Price => this.price;

        public int Weight => this.weight;
    }
}
