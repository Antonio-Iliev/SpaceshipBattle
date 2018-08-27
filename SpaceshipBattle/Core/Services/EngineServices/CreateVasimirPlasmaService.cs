using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Engines;

namespace SpaceshipBattle.Core.Services.EngineServices
{
    public class CreateVasimirPlasmaService : IEngineService
    {
        private const string engineModel = "Vasimir Plasma Engine";
        private const int price = 3500;
        private const int weight = 600;
        private const int power = 2860;
        private const FuelType fuelType = FuelType.Plasma;
        private const int thrust = 6;

        public ISpaceshipEngine CreateEngine()
        {
            return new HighTechEngine(engineModel, price, weight, power, fuelType, thrust);
        }
    }
}
