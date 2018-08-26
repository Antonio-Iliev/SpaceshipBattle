using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core.Services.ArmorServices
{
    public class CreateSwitzArmourService : IArmorService
    {
        private const string armorModel = "Switz Armour";
        private const int price = 2500;
        private const int weight = 800;
        private const int points = 35;
        private const int hardness = 3;
        private const int toughness = 2;
        private const ArmourType armorType = ArmourType.Steel;

        public IArmour CreateArmor()
        {
            return new DenseArmour(armorModel, price, weight, points, hardness, toughness, armorType);
        }
    }
}
