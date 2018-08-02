using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core;
using SpaceshipBattle.Core.Providers;
using SpaceshipsBattle.Core.GameController;

namespace SpaceshipsBattle
{
    public class StartUp
    {

        public static void Main()
        {
            PlayerCreator playerCreator = new PlayerCreator();
            GameController gameController = new GameController();
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            var engine = new GameEngine(playerCreator, gameController, writer, reader);
            engine.Start();
        }

    }
}
