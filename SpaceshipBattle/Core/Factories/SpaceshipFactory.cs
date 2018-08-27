using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Contracts;
using Autofac;
using SpaceshipBattle.Core.Services.SpaceShipService;

namespace SpaceshipBattle.Core.Factories
{
    class SpaceshipFactory : ISpaceshipFactory
    {

        private readonly IComponentContext autofacContext;

        public SpaceshipFactory(IComponentContext autofacContext)
        {
            this.autofacContext = autofacContext;
        }

        public ISpaceShip CreateSpaceship(string model, ISpaceshipEngine engine, IArmour armour, IWeapon weapon)
        {
            var command = this.autofacContext.ResolveNamed<ISpaceShipService>(model.ToLower());
            return command.CreateSpaceship(model, engine, armour, weapon);
        }
    }
}