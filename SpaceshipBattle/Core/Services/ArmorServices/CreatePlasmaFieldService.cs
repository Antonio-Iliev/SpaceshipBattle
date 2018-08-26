using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;

namespace SpaceshipBattle.Core.Services.ArmorServices
{
    public class CreatePlasmaFieldService : IArmorService
    {
        private const string armorModel = "Plasma Field";
        private const int price = 2800;
        private const int weight = 100;
        private const int points = 35;
        private const int reflection = 2;
        private const int refraction = 8;
        private const ArmourType armorType = ArmourType.Plasma;

        public IArmour CreateArmor()
        {
            return new ProtectiveFields(armorModel, price, weight, points, reflection, refraction, armorType);
        }
    }
}
