using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Engines;

namespace SpaceshipBattle.Core.Services.EngineServices
{
    public class CreateBugattiW16Service: IEngineService
    {

        private const string engineModel = "Bugatti W16";
        private const int price = 4000;
        private const int weight = 400;
        private const int power = 1001;
        private const FuelType fuelType = FuelType.Petrol;
        private const int torque = 1250;
        private const int capacity = 8000;
        private const int cylinderCount = 16;
        
        public ISpaceshipEngine CreateEngine()
        {
            return new AutomobileEngine(engineModel, price, weight, power, fuelType, torque, capacity, cylinderCount);
        }
    }
}
