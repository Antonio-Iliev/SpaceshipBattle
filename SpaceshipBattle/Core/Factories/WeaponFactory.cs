using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Contracts;
using System;
using Autofac;
using System.Windows.Input;
using SpaceshipBattle.Core.Services;

namespace SpaceshipBattle.Core.Factories
{
    class WeaponFactory : IWeaponFactory
    {

        private readonly IComponentContext autofacContext;

        public WeaponFactory(IComponentContext autofacContext)
        {
            this.autofacContext = autofacContext;
        }

        public IWeapon CreateWeapon(string model)
        {
            // resolve a concrete implementation of ICommand through its 'name'
            // e.g. "createtable" -> instance of type `CreateTableCommand`

            var command = this.autofacContext.ResolveNamed<IService>(model.ToLower());
            return command.CreateWeapon();
        }
        //switch (model)
        //{
        //    case "AK47":
        //        return new CriticalStrikeWeapon("AK47", 2000, 20, 8, 4, 200, 30);

        //    case "Cannon":
        //        return new AreaOfEffectWeapon("Cannon", 3000, 30, 12, 2, 50, 1);

        //    case "Laser":
        //        return new CriticalStrikeWeapon("Laser", 2500, 20, 10, 3, 100, 25);

        //    case "Plasma Weapon":
        //        return new AreaOfEffectWeapon("Plasma Weapon", 4000, 40, 15, 2, 40, 2);
        //    default: throw new ArgumentException("Please select valid weapon!");
        //}
    }
}


