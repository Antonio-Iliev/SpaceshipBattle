using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Entities.Armours;
using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipBattle.Contracts;
using System;
using Autofac;
using SpaceshipBattle.Core.Services.ArmorServices;

namespace SpaceshipBattle.Core.Factories
{
    public class ArmourFactory : IArmourFactory
    {

        private readonly IComponentContext autofacContext;

        public ArmourFactory(IComponentContext autofacContext)
        {
            this.autofacContext = autofacContext;
        }
        public IArmour CreateArmour(string model)
        {
            var command = this.autofacContext.ResolveNamed<IArmorService>(model.ToLower());
            return command.CreateArmor();
        }
    }
    //{
    //    switch (model)
    //    {
    //        case "Recycled Paper":
    //            return new DenseArmour("Recycled Paper", 1000, 50, 20, 0, 2, ArmourType.Paper);
    //        case "Brick cage":
    //            return new DenseArmour("Brick cage", 1500, 800, 25, 6, 0, ArmourType.Brick);
    //        case "Aerogel cover":
    //            return new DenseArmour("Aerogel cover", 2000, 500, 30, 2, 5, ArmourType.Aerogel);
    //        case "Fullerenes Armour":
    //            return new DenseArmour("Fullerenes Armour", 3500, 200, 40, 7, 3, ArmourType.Carbon);
    //        case "Switz Armour":
    //            return new DenseArmour("Switz Armour", 2500, 800, 35, 3, 2, ArmourType.Steel);
    //        case "Bubble Field":
    //            return new ProtectiveFields("Bubble Field", 1600, 100, 12, 4, 1, ArmourType.Plasma);
    //        case "Plasma Field":
    //            return new ProtectiveFields("Plasma Field", 2800, 100, 35, 2, 8, ArmourType.Plasma);
    //        case "Anti Matter Fields":
    //            return new ProtectiveFields("Anti Matter Field", 4000, 450, 65, 0, 10, ArmourType.AntiMatter);
    //        default:
    //            throw new ArgumentException("There is no such armour!");
    //    }
}
    