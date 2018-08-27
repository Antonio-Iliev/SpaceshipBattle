using SpaceshipBattle.Entities.Engines;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Factories;
using System;
using Autofac;
using SpaceshipBattle.Core.Services.EngineServices;

namespace SpaceshipBattle.Core.Factories
{
    public class EngineFactory : IEngineFactory
    {

        private readonly IComponentContext autofacContext;

        public EngineFactory(IComponentContext autofacContext)
        {
            this.autofacContext = autofacContext;
        }

        public ISpaceshipEngine CreateEngine(string model)
        {
            var command = this.autofacContext.ResolveNamed<IEngineService>(model.ToLower());
            return command.CreateEngine();
        }

        //public ISpaceshipEngine CreateEngine(string model)
        //{
        //    switch (model)
        //    {
        //        case "Trabant Motor":
        //            return new AutomobileEngine("Trabant Motor", 1000, 110, 26, FuelType.Petrol, 55, 594, 2);
        //        // 26 + 55 + 59 + 20 = 161 step 1
        //        case "VW 1.9 TDI":
        //            return new AutomobileEngine("VW 1.9 TDI", 1500, 200, 150, FuelType.Diesel, 320, 1900, 4);
        //        // 700 step 1
        //        case "Ferrari V12 GT":
        //            return new AutomobileEngine("Ferrari V12 GT", 3500, 340, 789, FuelType.Petrol, 718, 6500, 12);
        //        //  step 2
        //        case "Bugatti W16":
        //            return new AutomobileEngine("Bugatti W16", 4000, 400, 1001, FuelType.Petrol, 1250, 8000, 16); // 3211 step 3
        //        case "H2O Motor":
        //            return new HighTechEngine("H2O Motor", 1000, 220, 980, FuelType.Water, 1); // step 1 980 + 100 = 1080
        //        case "Ion X3":
        //            return new HighTechEngine("Ion X3", 2000, 400, 2120, FuelType.Ion, 2); //step 2 2320
        //        case "Vasimir Plasma Engine":
        //            return new HighTechEngine("Vasimir Plasma Engine ", 3500, 600, 2860, FuelType.Plasma, 6); // step 3 3460
        //        default: throw new ArgumentException("There is no such model!");
        //    }
        //}

    }
}
