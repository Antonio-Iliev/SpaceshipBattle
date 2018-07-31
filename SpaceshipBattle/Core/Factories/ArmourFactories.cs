using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipsBattle.Contracts;
using System;

namespace SpaceshipBattle.Core.Factories
{
    public class ArmoursFactories : IArmourFactory
    {
        public IArmour CreatEngine(string model)
        {
            switch (model)
            {
                case "Recycled Paper":
                    return new DenseArmour("Recycled Paper", 100, 20, 100, ArmourType.Paper);
                case "Brick cage":
                    return new DenseArmour("Brick cage", 100, 60, 250, ArmourType.Brick);
                case "Aerogel Armour":
                    return new DenseArmour("Aerogel Armour", 100, 40, 220, ArmourType.Aerogel);
                case "Fullerenes Armour":
                    return new DenseArmour("Fullerenes Armour", 100, 80, 300, ArmourType.Carbon);
                case "Switz Armour":
                    return new DenseArmour("Switz Armour", 100, 50, 250, ArmourType.Steel);
                case "Plasma Fields":
                    return new ProtectiveFields("Plasma Armour", 100, 2, 150, ArmourType.Plasma);
                case "Anti Matter Fields":
                    return new ProtectiveFields("Anti Matter Fields", 100, 5, 260, ArmourType.AntiMatter);
                default:
                    throw new ArgumentException("There is no such a model!");
            }
        }
    }
}
