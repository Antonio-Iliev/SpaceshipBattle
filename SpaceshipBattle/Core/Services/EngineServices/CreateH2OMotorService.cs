using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Engines;

namespace SpaceshipBattle.Core.Services.EngineServices
{
   public class CreateH2OMotorService : IEngineService
    {
        private const string engineModel = "H2O Motor";
        private const int price = 1000;
        private const int weight = 220;
        private const int power = 980;
        private const FuelType fuelType = FuelType.Water;
        private const int thrust = 1;
        
        public ISpaceshipEngine CreateEngine()
        {
            return new HighTechEngine(engineModel, price, weight, power, fuelType, thrust);
        }
    }
}
