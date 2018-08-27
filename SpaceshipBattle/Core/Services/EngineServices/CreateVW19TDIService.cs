using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Engines;

namespace SpaceshipBattle.Core.Services.EngineServices
{
    public class CreateVW19TDIService : IEngineService
    {
        private const string engineModel = "VW 1.9 TDI";
        private const int price = 1500;
        private const int weight = 200;
        private const int power = 150;
        private const FuelType fuelType = FuelType.Diesel;
        private const int torque = 320;
        private const int capacity = 1900;
        private const int cylinderCount = 4;
        
        public ISpaceshipEngine CreateEngine()
        {
            return new AutomobileEngine(engineModel, price, weight, power, fuelType, torque, capacity, cylinderCount);
        }
    }
}
