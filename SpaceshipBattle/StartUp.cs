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

        }

    }
}
