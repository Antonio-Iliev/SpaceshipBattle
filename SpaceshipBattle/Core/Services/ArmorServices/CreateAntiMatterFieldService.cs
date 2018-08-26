using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;

namespace SpaceshipBattle.Core.Services.ArmorServices
{
    public class CreateAntiMatterFieldService : IArmorService
    {
        private const string armorModel = "Anti Matter Field";
        private const int price = 5000;
        private const int weight = 450;
        private const int points = 65;
        private const int reflection = 0;
        private const int refraction = 10;
        private const ArmourType armorType = ArmourType.AntiMatter;

        public IArmour CreateArmor()
        {
            return new ProtectiveFields(armorModel, price, weight, points, reflection, refraction, armorType);
        }
    }
}
