using Autofac;
using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core;
using SpaceshipBattle.Core.Factories;
using SpaceshipBattle.Core.Providers;
using System.Reflection;

namespace SpaceshipBattle
{
    public class StartUp
    {
        public static void Main()
        {

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var conteiner = builder.Build();
            var engine = conteiner.Resolve<IEngine>();

            engine.Start();


            //IEngineFactory engineFactory = new EngineFactory();
            //IArmourFactory armourFactory = new ArmourFactory();
            //IWeaponFactory weaponFactory = new WeaponFactory();
            //ISpaceshipFactory spaceshipFactory = new SpaceshipFactory();
            //IBulletFactory bulletFactory = new BulletFactory();
            //IPlayerFactory playerFactory = new PlayerFactory();
            
            //IWriter writer = new ConsoleWriter();
            //IConsoleReader reader = new ConsoleReader();

            //PlayerCreator playerCreator = new PlayerCreator(playerFactory, engineFactory, armourFactory, weaponFactory, spaceshipFactory, bulletFactory);
            //GameController gameController = new GameController(writer, reader);
            //Registration player1 = new Registration(reader, writer);
            //Registration player2 = new Registration(reader, writer);

            //var engine = new Engine(playerCreator, gameController, player1, player2, writer, reader);
            //engine.Start();


        }

    }
}
