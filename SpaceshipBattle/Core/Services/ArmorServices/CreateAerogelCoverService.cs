using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;

namespace SpaceshipBattle.Core.Services.ArmorServices
{
    public class CreateAerogelCoverService : IArmorService
    {
        private const string armorModel = "Aerogel cover";
        private const int price = 2000;
        private const int weight = 500;
        private const int points = 30;
        private const int hardness = 2;
        private const int toughness = 5;
        private const ArmourType armorType = ArmourType.Aerogel;

        public IArmour CreateArmor()
        {
            return new DenseArmour(armorModel, price, weight, points, hardness, toughness, armorType);
        }
    }
}
