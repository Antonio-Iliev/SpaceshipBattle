using SpaceshipBattle.Entities.Engines;
using SpaceshipBattle.Contracts.Entities.Engines;
using SpaceshipBattle.Contracts;

namespace SpaceshipBattle.Core.Services.EngineServices
{
    public class CreateTrabantMotorService :IEngineService
    {
        private const string engineModel = "Trabant Motor";
        private const int price = 1000;
        private const int weight = 110;
        private const int power = 26;
        private const FuelType fuelType = FuelType.Petrol;
        private const int torque = 55;
        private const int capacity = 594;
        private const int cylinderCount = 2;

        public ISpaceshipEngine CreateEngine()
        {
           return new AutomobileEngine(engineModel, price, weight, power, fuelType, torque, capacity, cylinderCount);          
        }
    }
}
