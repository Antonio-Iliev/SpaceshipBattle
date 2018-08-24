using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core.Common;
using System;
using System.Threading;

namespace SpaceshipBattle.Core
{
    public class GameController : IGameController
    {
        private IWriter writer;
        private readonly IConsoleReader reader;
        private bool hasWinner = false;
        private string winnerName = string.Empty;
        private  int windowWidth = 120;
        private  int windowHeight = 35;

        public GameController(IWriter writer, IConsoleReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        private void RemoveScrollBars()
        {
            writer.SetTextColor(Colors.Red);
            writer.SetWindowSize(windowWidth, windowHeight);

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        private void PrintAtPosition(int x, int y, char symbol)
        {
            writer.SetCursorPosition(x, y);
            writer.Write(symbol);
        }

        private void PrintAtPosition(int x, int y, string message)
        {
            writer.SetCursorPosition(x, y);
            writer.Write(message);
        }

        private void SetInitialPositions(IPlayer player)
        {
            player.Spaceship.PositionY = Console.WindowHeight / 2;
        }

        private void DrawBullet(int x, int y, char symbol)
        {
            PrintAtPosition(x, y, symbol);
        }

        private void PrintResult(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            //first player
            PrintAtPosition(10, 0, $"Armour:{firstPlayer.Spaceship.Armour.ArmourCoefficient}");
            PrintAtPosition(10, 1, $"Health:{firstPlayer.Spaceship.Health}");

            //second player
            PrintAtPosition(Console.WindowWidth - 20, 0, $"Armour:{secondPlayer.Spaceship.Armour.ArmourCoefficient}");
            PrintAtPosition(Console.WindowWidth - 20, 1, $"Health:{secondPlayer.Spaceship.Health}");

        }

        public void Play(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            RemoveScrollBars();
            SetInitialPositions(firstPlayer);
            SetInitialPositions(secondPlayer);

            while (true)
            {
                if (writer.KeyAvailable())
                {
                    ConsoleKeyInfo keyInfo = reader.ReadKey();
                    CommandParser(firstPlayer, secondPlayer, keyInfo);
                }

                writer.ClearScreen();

                ManageShooting(firstPlayer, secondPlayer);

                if (hasWinner)
                {
                    break;
                }

                DrawShip.DrawShipPlayerOne(firstPlayer);
                DrawShip.DrawShipPlayerTwo(secondPlayer);

                DrawBullet(firstPlayer, 'A');
                DrawBullet(secondPlayer, 'B');

                PrintResult(firstPlayer, secondPlayer);
                Thread.Sleep(50);
            }

            writer.WriteColorTextCenter($"{winnerName} wins!");
        }

        private void ManageShooting(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            if (firstPlayer.Spaceship.IsAtShooting)
            {
                //move first player bullet
                firstPlayer.Spaceship.Weapon.Bullet.PositionX += firstPlayer.Spaceship.Weapon.Speed * 3;

                bool firstPlBulletOutOfRange = firstPlayer.Spaceship.Weapon.Bullet.PositionX + firstPlayer.Spaceship.Weapon.Speed >= Console.WindowWidth;
                if (firstPlBulletOutOfRange)
                {
                    TakeDamage(firstPlayer, secondPlayer);
                    firstPlayer.Spaceship.IsAtShooting = false;
                }
            }

            if (secondPlayer.Spaceship.IsAtShooting)
            {
                //move second player bullet
                secondPlayer.Spaceship.Weapon.Bullet.PositionX -= secondPlayer.Spaceship.Weapon.Speed * 3;

                bool secondPlBulletOutOfRange = secondPlayer.Spaceship.Weapon.Bullet.PositionX - secondPlayer.Spaceship.Weapon.Speed <= 0;

                if (secondPlBulletOutOfRange)
                {
                    TakeDamage(secondPlayer, firstPlayer);
                    secondPlayer.Spaceship.IsAtShooting = false;
                }
            }
        }

        private void DrawBullet(IPlayer player, char symbol)
        {
            if (player.Spaceship.IsAtShooting)
            {
                PrintAtPosition(player.Spaceship.Weapon.Bullet.PositionX, player.Spaceship.Weapon.Bullet.PositionY, symbol);
            }
        }

        private void TakeDamage(IPlayer playerShooting, IPlayer playerShot)
        {
            //Calculate the damage to be dealt
            var dealDamage = playerShooting.Spaceship.Weapon.DealDamage(playerShooting.Spaceship.Weapon.Bullet.PositionY, playerShot.Spaceship.PositionY);

            //Take the damage from the ship
            playerShooting.Spaceship.TakeDamageToPlayer(playerShot, dealDamage);

            if (playerShot.Spaceship.Health <= 0)
            {
                hasWinner = true;
                winnerName = playerShooting.Name;
            }
        }

        private void CommandParser(IPlayer firstPlayer, IPlayer secondPlayer, ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.W)
            {
                firstPlayer.Spaceship.MoveUp();
            }

            if (keyInfo.Key == ConsoleKey.S)
            {
                firstPlayer.Spaceship.MoveDown();
            }

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                secondPlayer.Spaceship.MoveUp();
            }

            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                secondPlayer.Spaceship.MoveDown();
            }

            //Shoot first player
            if (keyInfo.Key == ConsoleKey.Q)
            {
                firstPlayer.Spaceship.ShootFromLeftSide();
            }

            if (keyInfo.Key == ConsoleKey.L)
            {
                secondPlayer.Spaceship.ShootFromRightSide();
            }
        }
    }
}
