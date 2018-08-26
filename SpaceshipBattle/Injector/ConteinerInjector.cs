using Autofac;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core;
using SpaceshipBattle.Core.Factories;
using SpaceshipBattle.Core.Providers;
using SpaceshipBattle.DataBase;
using SpaceshipBattle.Core.RegistrationEntities;
using SpaceshipBattle.Core.Registration;
using SpaceshipBattle.Core.Services;
using SpaceshipBattle.Core.Services.ArmorServices;

namespace SpaceshipBattle.Injector
{
    class ContainerInjector : Module
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
            builder.RegisterType<CreateAerogelCoverService>().Named<IArmorService>("aerogel cover");
            builder.RegisterType<CreateAntiMatterFieldService>().Named<IArmorService>("anti matter field");
            builder.RegisterType<CreateBrickCageService>().Named<IArmorService>("brick cage");
            builder.RegisterType<CreateBubbleFieldService>().Named<IArmorService>("bubble field");
            builder.RegisterType<CreateFullerenesArmourService>().Named<IArmorService>("fullerenes armour");
            builder.RegisterType<CreatePlasmaFieldService>().Named<IArmorService>("plasma field");
            builder.RegisterType<CreateAntiMatterFieldService>().Named<IArmorService>("recycled paper");
            builder.RegisterType<CreateSwitzArmourService>().Named<IArmorService>("switz rmour");
            builder.RegisterType<WeaponFactory>().As<IWeaponFactory>();
            builder.RegisterType<CreateAK47Service>().Named<IWeaponService>("ak47");
            builder.RegisterType<CreateCannonService>().Named<IWeaponService>("cannon");
            builder.RegisterType<CreateLaserService>().Named<IWeaponService>("laser");
            builder.RegisterType<CreatePlasmaWeaponService>().Named<IWeaponService>("plasmaweapon");
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
            builder.RegisterType<SelectingSpaceship>().As<ISelectingSpaceship>();
            builder.RegisterType<FilterComponents>().As<IFilterComponents>();

        }

        private void RegisterProvidersComponents(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleWriter>().As<IWriter>();
            builder.RegisterType<ConsoleReader>().As<IReader>();
            builder.RegisterType<LocalDataBase>().As<IDataBase>();
            builder.RegisterType<ConsoleApplicationInterface>().As<IApplicationInterface>();
            builder.RegisterType<Menu>().As<IMenu>();
        }
    }
}
