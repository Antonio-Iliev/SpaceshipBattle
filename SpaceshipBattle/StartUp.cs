using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core;
using SpaceshipBattle.Core.Providers;

namespace SpaceshipBattle
{
    public class StartUp
    {

        public static void Main()
        {
            PlayerCreator playerCreator = new PlayerCreator();
            GameController gameController = new GameController();
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            var engine = new Engine(playerCreator, gameController, writer, reader);
            engine.Start();
        }

    }
}
