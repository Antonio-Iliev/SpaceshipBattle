using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Providers;
using System;
using System.Threading;

namespace SpaceshipBattle.Core
{
    public class GameController : IGameController
    {
        private IWriter writer;
        private IReader reader;
        private bool hasWinner = false;
        private string winnerName = string.Empty;

        public GameController(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        private void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetWindowSize(120, 35);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        private void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            writer.Write(symbol.ToString());
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
            Console.SetCursorPosition(10, 0);
            writer.Write($"Armour:{firstPlayer.Spaceship.Armour.ArmourCoefficient}");
            Console.SetCursorPosition(10, 1);
            writer.Write($"Health:{firstPlayer.Spaceship.Health}");

            //second player
            Console.SetCursorPosition(Console.WindowWidth - 20, 0);
            writer.Write($"Armour:{secondPlayer.Spaceship.Armour.ArmourCoefficient}");
            Console.SetCursorPosition(Console.WindowWidth - 20, 1);
            writer.Write($"Health:{secondPlayer.Spaceship.Health}");
        }

        public void Play(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            RemoveScrollBars();
            SetInitialPositions(firstPlayer);
            SetInitialPositions(secondPlayer);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    CommandParser(firstPlayer, secondPlayer, keyInfo);
                }

                Console.Clear();

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
                Thread.Sleep(45);
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

        private void TakeDamage(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            if (firstPlayer.Spaceship.Weapon.Bullet.PositionY >= secondPlayer.Spaceship.PositionY - 2 && firstPlayer.Spaceship.Weapon.Bullet.PositionY <= secondPlayer.Spaceship.PositionY + 2)
            {
                firstPlayer.Spaceship.TakeDamageToPlayer(secondPlayer, firstPlayer.Spaceship.Weapon.DealDamage(firstPlayer, secondPlayer));
            }
            else if (firstPlayer.Spaceship.Weapon.Model == "Plasma Weapon" || firstPlayer.Spaceship.Weapon.Model == "Cannon")
            {
                firstPlayer.Spaceship.TakeDamageToPlayer(secondPlayer, firstPlayer.Spaceship.Weapon.DealDamage(firstPlayer, secondPlayer));
            }

            if (secondPlayer.Spaceship.Health <= 0)
            {
                hasWinner = true;
                winnerName = firstPlayer.Name;
            }

        }

        private void CommandParser(IPlayer firstPlayer, IPlayer secondPlayer, ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.W)
            {
                firstPlayer.Spaceship.Move("up");
            }

            if (keyInfo.Key == ConsoleKey.S)
            {
                firstPlayer.Spaceship.Move("down");
            }

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                secondPlayer.Spaceship.Move("up");
            }

            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                secondPlayer.Spaceship.Move("down");
            }

            //Shoot first player
            if (keyInfo.Key == ConsoleKey.Q)
            {
                firstPlayer.Spaceship.Shoot("left");
            }

            if (keyInfo.Key == ConsoleKey.L)
            {
                secondPlayer.Spaceship.Shoot("right");
            }
        }
    }
}
