using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;

namespace SpaceshipBattle.Core.Services.ArmorServices
{
    public class CreateFullerenesArmourService : IArmorService
    {
        private const string armorModel = "Fullerenes Armour";
        private const int price = 3500;
        private const int weight = 200;
        private const int points = 40;
        private const int hardness = 7;
        private const int toughness = 3;
        private const ArmourType armorType = ArmourType.Carbon;

        public IArmour CreateArmor()
        {
            return new DenseArmour(armorModel, price, weight, points, hardness, toughness, armorType);
        }
    }
}
