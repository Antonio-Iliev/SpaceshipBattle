﻿using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core.Providers;
using SpaceshipsBattle.Contracts;
using SpaceshipsBattle.Core.GameController;
using SpaceshipsBattle.Entities.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core
{
    public class GameEngine : IGameEngine
    {
        //TODO implement IPlayerCreator and IGameController
        private PlayerCreator playerCreator;
        private GameController gameController;

        public GameEngine(PlayerCreator playerCreator, GameController gameController, IWriter writer, IReader reader)
        {
            this.playerCreator = playerCreator;
            this.gameController = gameController;
            this.Reader = reader;
            this.Writer = writer;
        }

        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }

        public void Start()
        {
            Writer.Write("Please enter first player name: ");
            string firstPlayerName = Reader.ReadLine();
            Writer.Write("Select a spaceship model: ");
            string spaceshipModel = Reader.ReadLine();
            Writer.Write("Select an engine: ");
            string engineModel = Reader.ReadLine();
            Writer.Write("Select an armour: ");
            string armourModel = Reader.ReadLine();
            Writer.Write("Select a weapon: ");
            string weaponModel = Reader.ReadLine();

            IPlayer firstPlayer = playerCreator.CreatePlayer(firstPlayerName, spaceshipModel, engineModel, armourModel, weaponModel);

            Writer.Write("Please enter second player name: ");
            string secondPlayerName = Reader.ReadLine();
            Writer.Write("Select a spaceship model: ");
            spaceshipModel = Reader.ReadLine();
            Writer.Write("Select an engine: ");
            engineModel = Reader.ReadLine();
            Writer.Write("Select an armour: ");
            armourModel = Reader.ReadLine();
            Writer.Write("Select a weapon: ");
            weaponModel = Reader.ReadLine();

            IPlayer secondPlayer = playerCreator.CreatePlayer(firstPlayerName, spaceshipModel, engineModel, armourModel, weaponModel);

            gameController.Play(firstPlayer, secondPlayer);
        }
    }
}
