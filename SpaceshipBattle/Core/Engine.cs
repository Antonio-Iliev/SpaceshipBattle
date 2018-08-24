using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Contracts;
using SpaceshipBattle.Entities.Spaceships;
using System;

namespace SpaceshipBattle.Core
{
    public class Engine : IEngine
    {
        private IPlayerCreator playerCreator;
        private IGameController gameController;
        private Registration player1;
        private Registration player2;

        public Engine(IPlayerCreator playerCreator, IGameController gameController, Registration player1, Registration player2, IWriter writer, IReader reader)
        {
            this.playerCreator = playerCreator;
            this.gameController = gameController;
            this.player1 = player1;
            this.player2 = player2;

            this.Reader = reader;
            this.Writer = writer;
        }

        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }

        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize(120, 35);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            try
            {
                player1.ChooseName();
                player1.ChooseSpaceShip();
                player1.ChooseComponent();
                Writer.WriteColorTextCenter(">>> " + player1.ParametersForPlayer["name"] + ". <<<<  -  You are ready for fight!!!");

                player2.ChooseName();
                player2.ChooseSpaceShip();
                player2.ChooseComponent();
                Writer.WriteColorTextCenter(">>> " + player2.ParametersForPlayer["name"] + ". <<<<  -  You are ready for fight!!!");

                IPlayer firstPlayer = playerCreator.CreatePlayer(player1);
                IPlayer secondPlayer = playerCreator.CreatePlayer(player2);

                gameController.Play(firstPlayer, secondPlayer);
            }
            catch (Exception ex)
            {
                Writer.WriteColorTextCenter(ex.Message);
            }               
        }
    }
}
