using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;

namespace SpaceshipBattle.Core.Services.ArmorServices
{
   public class CreateBrickCageService : IArmorService
    {
        private const string armorModel = "Brick cage";
        private const int price = 1500;
        private const int weight = 800;
        private const int points = 25;
        private const int hardness = 6;
        private const int toughness = 0;
        private const ArmourType armorType = ArmourType.Brick;

        public IArmour CreateArmor()
        {
            return new DenseArmour(armorModel, price, weight, points, hardness, toughness, armorType);
        }
    }
}
