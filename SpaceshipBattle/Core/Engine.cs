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
        private IRegistration player;
        private IRegistration player2;
        private readonly IApplicationInterface applicationInterface;

        public Engine
            (IPlayerCreator playerCreator,
             IGameController gameController,
             IRegistration player,
             IWriter writer,
             IReader reader,
             IApplicationInterface applicationInterface)
        {
            this.playerCreator = playerCreator;
            this.gameController = gameController;
            this.player = player;
            this.Reader = reader;
            this.applicationInterface = applicationInterface;
            this.Writer = writer;
        }

        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }

        public void Start()
        {
            applicationInterface.SetGameDisplay();

            try
            {
                var registrationPlayer1 = player.RegistrationForPlayer();
                Writer.WriteColorTextCenter(registrationPlayer1);
                IPlayer firstPlayer = playerCreator.CreatePlayer(player);

                var registrationPlayer2 = player.RegistrationForPlayer();
                Writer.WriteColorTextCenter(registrationPlayer2);
                IPlayer secondPlayer = playerCreator.CreatePlayer(player);

                gameController.Play(firstPlayer, secondPlayer);
            }
            catch (Exception ex)
            {
                Writer.WriteColorTextCenter(ex.Message);
            }
        }
    }
}
