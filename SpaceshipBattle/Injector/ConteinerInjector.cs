using Autofac;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core;
using SpaceshipBattle.Core.Factories;
using SpaceshipBattle.Core.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Injector
{
    class ConteinerInjector : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Engine>().As<IEngine>();

            builder.RegisterType<EngineFactory>().As<IEngineFactory>();
            builder.RegisterType<ArmourFactory>().As<IArmourFactory>();
            builder.RegisterType<WeaponFactory>().As<IWeaponFactory>();
            builder.RegisterType<SpaceshipFactory>().As<ISpaceshipFactory>();
            builder.RegisterType<BulletFactory>().As<IBulletFactory>();
            builder.RegisterType<PlayerFactory>().As<IPlayerFactory>();

            builder.RegisterType<Registration>().As<IRegistration>();
            builder.RegisterType<PlayerCreator>().As<IPlayerCreator>();
            builder.RegisterType<GameController>().As<IGameController>();

            builder.RegisterType<ConsoleWriter>().As<IWriter>();
            builder.RegisterType<ConsoleReader>().As<IReader>();


            base.Load(builder);
        }
    }
}
