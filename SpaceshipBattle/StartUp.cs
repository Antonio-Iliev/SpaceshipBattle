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
            Registration player1 = new Registration(reader, writer);
            Registration player2 = new Registration(reader, writer);

            var engine = new Engine(playerCreator, gameController, player1, player2, writer, reader);
            engine.Start();
        }

    }
}
