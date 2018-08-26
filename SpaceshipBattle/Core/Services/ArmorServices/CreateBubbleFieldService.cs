using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;

namespace SpaceshipBattle.Core.Services.ArmorServices
{
    public class CreateBubbleFieldService : IArmorService
    {
        private const string armorModel = "Bubble Field";
        private const int price = 1600;
        private const int weight = 100;
        private const int points = 12;
        private const int reflection = 4;
        private const int refraction = 1;
        private const ArmourType armorType = ArmourType.Plasma;

        public IArmour CreateArmor()
        {
            return new ProtectiveFields(armorModel, price, weight, points, reflection, refraction, armorType);
        }
    }
}
