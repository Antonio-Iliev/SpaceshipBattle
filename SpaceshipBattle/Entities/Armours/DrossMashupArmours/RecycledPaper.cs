using SpaceshipsBattle.Contracts;
using SpaceshipsBattle.Entities.Armour;

namespace SpaceshipBattle.Entities.Armours
{
    class RecycledPaper : IArmour
    {
        private readonly string model = "Recycled Paper";
        private readonly int points = 100;
        private readonly int price = 20;
        private readonly int weight = 30;

        public string Model => this.model;

        public int Points => this.points;

        public int Price => this.price;

        public int Weight => this.weight;

    }
}
