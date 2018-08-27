using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Engines;

namespace SpaceshipBattle.Core.Services.EngineServices
{
    public class CreateIonX3Service : IEngineService
    {
        private const string engineModel = "Ion X3";
        private const int price = 2000;
        private const int weight = 400;
        private const int power = 2120;
        private const FuelType fuelType = FuelType.Ion;
        private const int thrust = 2;

        public ISpaceshipEngine CreateEngine()
        {
            return new HighTechEngine(engineModel, price, weight, power, fuelType, thrust);
        }
    }
}
