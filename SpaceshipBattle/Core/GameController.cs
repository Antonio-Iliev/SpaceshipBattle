using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core.Common;
using System;
using System.Threading;

namespace SpaceshipBattle.Core
{
    public class GameController : IGameController
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IApplicationInterface appInterface;
        private bool hasWinner = false;
        private string winnerName = string.Empty;

        public GameController(IWriter writer, IReader reader, IApplicationInterface appInterface)
        {
            this.writer = writer;
            this.reader = reader;
            this.appInterface = appInterface;
        }

        public void Play(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            appInterface.SetGameDisplay();
            SetInitialPositions(firstPlayer);
            SetInitialPositions(secondPlayer);

            while (true)
            {
                if (writer.KeyAvailable())
                {
                    var keyInfo = reader.ReadKey();
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
                appInterface.FreezeScreen(40);
            }

            writer.WriteColorTextCenter($"{winnerName} wins!");
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
            player.Spaceship.PositionY = appInterface.WindowHeight / 2;
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
            PrintAtPosition(appInterface.WindowWidth - 20, 0, $"Armour:{secondPlayer.Spaceship.Armour.ArmourCoefficient}");
            PrintAtPosition(appInterface.WindowWidth - 20, 1, $"Health:{secondPlayer.Spaceship.Health}");

        }

        private void ManageShooting(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            if (firstPlayer.Spaceship.IsAtShooting)
            {
                //Move first player bullet
                firstPlayer.Spaceship.Weapon.Bullet.PositionX += firstPlayer.Spaceship.Weapon.Speed * 3;

                bool firstPlBulletOutOfRange = firstPlayer.Spaceship.Weapon.Bullet.PositionX + firstPlayer.Spaceship.Weapon.Speed >= appInterface.WindowWidth;
                if (firstPlBulletOutOfRange)
                {
                    TakeDamage(firstPlayer, secondPlayer);
                    firstPlayer.Spaceship.IsAtShooting = false;
                }
            }

            if (secondPlayer.Spaceship.IsAtShooting)
            {
                //Move second player bullet
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
            playerShooting.Spaceship.TakeDamageToPlayer(playerShot.Spaceship, dealDamage);

            //There is a winner
            if (playerShot.Spaceship.Health <= 0)
            {
                hasWinner = true;
                winnerName = playerShooting.Name;
            }
        }

        private void MoveDown(IPlayer player)
        {
            if (player.Spaceship.PositionY + player.Spaceship.Speed < appInterface.WindowHeight - 2)
            {
                player.Spaceship.PositionY += player.Spaceship.Speed;
                player.Spaceship.TotalDist += player.Spaceship.Speed;

                if (player.Spaceship.TotalDist >= player.Spaceship.FuelCapacity)
                {
                    player.Spaceship.Refuel();
                }
            }
        }

        private void MoveUp(IPlayer player)
        {
            if (player.Spaceship.PositionY - player.Spaceship.Speed > 1)
            {
                player.Spaceship.PositionY -= player.Spaceship.Speed;
                player.Spaceship.TotalDist += player.Spaceship.Speed;

                if (player.Spaceship.TotalDist >= player.Spaceship.FuelCapacity)
                {
                    player.Spaceship.Refuel();
                }
            }
        }

        private void PrepareToShoot(IPlayer player)
        {
            player.Spaceship.Weapon.Bullet.PositionY = player.Spaceship.PositionY;
            player.Spaceship.IsAtShooting = true;
        }

        private void ShootFromLeftSide(IPlayer player)
        {
            if (player.Spaceship.IsAtShooting == false)
            {
                PrepareToShoot(player);

                player.Spaceship.Weapon.Bullet.PositionX = 1;
            }
        }

        private void ShootFromRightSide(IPlayer player)
        {
            if (player.Spaceship.IsAtShooting == false)
            {
                PrepareToShoot(player);

                player.Spaceship.Weapon.Bullet.PositionX = appInterface.WindowWidth - 1;
            }
        }

        private void CommandParser(IPlayer firstPlayer, IPlayer secondPlayer, ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.W)
            {
                MoveUp(firstPlayer);
            }

            if (keyInfo.Key == ConsoleKey.S)
            {
                MoveDown(firstPlayer);
            }

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                MoveUp(secondPlayer);
            }

            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                MoveDown(secondPlayer);
            }

            //Shoot first player
            if (keyInfo.Key == ConsoleKey.Q)
            {
                ShootFromLeftSide(firstPlayer);
            }

            //Shoot second player
            if (keyInfo.Key == ConsoleKey.L)
            {
                ShootFromRightSide(secondPlayer);
            }
        }
    }
}
