using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;

namespace SpaceshipBattle.Core.Services.ArmorServices
{
    public class CreateRecycledPaperService
    {
        private const string armorModel = "Recycled Paper";
        private const int price = 1000;
        private const int weight = 50;
        private const int points = 20;
        private const int hardness = 0;
        private const int toughness = 2;
        private const ArmourType armorType = ArmourType.Paper;
        public IArmour CreateArmor()
        {
            return new DenseArmour(armorModel, price, weight, points, hardness, toughness, armorType);
        }
    }
}
