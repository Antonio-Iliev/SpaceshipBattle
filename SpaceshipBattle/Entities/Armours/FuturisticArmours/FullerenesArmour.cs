using SpaceshipsBattle.Contracts;

namespace SpaceshipBattle.Entities.Armours.FuturisticArmours
{
    public class FullerenesArmour : IArmour
    {
        private readonly string model = "Fullerenes Armour";
        private readonly int points = 300;
        private readonly int price = 80;
        private readonly int weight = 160;

        public string Model => this.model;

        public int Points => this.points;

        public int Price => this.price;

        public int Weight => this.weight;

    }
}
