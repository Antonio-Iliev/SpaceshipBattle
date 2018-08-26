using System.Reflection;
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
using SpaceshipBattle.DataBase;
using SpaceshipBattle.Core.Services;

namespace SpaceshipBattle.Injector
{
    class ConteinerInjector : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            this.RegisterFactoryComponents(builder);
            this.RegisterCoreComponents(builder);
            this.RegisterProvidersComponents(builder);

            base.Load(builder);
        }

        private void RegisterFactoryComponents(ContainerBuilder builder)
        {
            builder.RegisterType<EngineFactory>().As<IEngineFactory>();
            builder.RegisterType<ArmourFactory>().As<IArmourFactory>();
            builder.RegisterType<WeaponFactory>().As<IWeaponFactory>();
            builder.RegisterType<CreateAK47Service>().Named<IService>("ak47");
            builder.RegisterType<CreateCannonService>().Named<IService>("cannon");
            builder.RegisterType<CreateLaserService>().Named<IService>("laser");
            builder.RegisterType<CreatePlasmaWeaponService>().Named<IService>("plasmaweapon");
            builder.RegisterType<SpaceshipFactory>().As<ISpaceshipFactory>();
            builder.RegisterType<BulletFactory>().As<IBulletFactory>();
            builder.RegisterType<PlayerFactory>().As<IPlayerFactory>();
        }

        private void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.RegisterType<Engine>().As<IEngine>();
            builder.RegisterType<Registration>().As<IRegistration>();
            builder.RegisterType<PlayerCreator>().As<IPlayerCreator>();
            builder.RegisterType<GameController>().As<IGameController>();
        }

        private void RegisterProvidersComponents(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleWriter>().As<IWriter>();
            builder.RegisterType<ConsoleReader>().As<IReader>();
            builder.RegisterType<LocalDataBase>().As<IDataBase>();
            builder.RegisterType<ConsoleApplicationInterface>().As<IApplicationInterface>();
        }
    }
}
