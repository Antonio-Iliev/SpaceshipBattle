using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Engines;

namespace SpaceshipBattle.Core.Services.EngineServices
{
    public class CreateFerrariV12GTService : IEngineService
    {
        private const string engineModel = "Ferrari V12 GT";
        private const int price = 3500;
        private const int weight = 340;
        private const int power = 789;
        private const FuelType fuelType = FuelType.Petrol;
        private const int torque = 718;
        private const int capacity = 6500;
        private const int cylinderCount = 12;
        
        public ISpaceshipEngine CreateEngine()
        {
            return new AutomobileEngine(engineModel, price, weight, power, fuelType, torque, capacity, cylinderCount);
        }
    }
}
