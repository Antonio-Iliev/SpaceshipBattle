﻿using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipBattle.Contracts;
using System;

namespace SpaceshipBattle.Core.Factories
{
    public class ArmourFactory : IArmourFactory
    {
        public IArmour CreateArmour(string model)
        {
            switch (model)
            {
                case "Paper":
                    return new DenseArmour("Recycled Paper", 1000, 50, 20, 0, 2, ArmourType.Paper);
                case "Brick cage":
                    return new DenseArmour("Brick cage", 1500, 800, 25, 6, 0, ArmourType.Brick);
                case "Aerogel":
                    return new DenseArmour("Aerogel Armour", 2000, 500, 30, 2, 5, ArmourType.Aerogel);
                case "Fullerenes":
                    return new DenseArmour("Fullerenes Armour", 3500, 200, 40, 7, 3, ArmourType.Carbon);
                case "Switz":
                    return new DenseArmour("Switz Armour", 2500, 2500, 35, 3, 2, ArmourType.Steel);
                case "Plasma":
                    return new ProtectiveFields("Plasma Armour", 1800, 100, 35, 2, 8, ArmourType.Plasma);
                case "AntiMatter":
                    return new ProtectiveFields("Anti Matter Fields", 5000, 450, 65, 0, 10, ArmourType.AntiMatter);
                default:
                    throw new ArgumentException("There is no such a model!");
            }
        }
    }
}
