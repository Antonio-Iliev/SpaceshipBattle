using SpaceshipBattle.Contracts;
using SpaceshipBattle.Contracts.Providers;
using System;
using System.Threading;

namespace SpaceshipBattle.Core
{
    public class GameController
    {
        private IWriter writer;
        private IReader reader;
        private bool hasWinner = false;
        private string winnerName = string.Empty;

        //TODO implement IGameController
        //TODO change console with reader and writer
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
            Console.Write(symbol);
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
            Console.SetCursorPosition(1, 0);
            Console.Write("Armour:{0}", firstPlayer.Spaceship.Armour.ArmourCoefficient);
            Console.SetCursorPosition(1, 1);
            Console.Write("Health:{0}", firstPlayer.Spaceship.Health);

            //second player
            Console.SetCursorPosition(Console.WindowWidth - 11, 0);
            Console.Write("Armour:{0}", secondPlayer.Spaceship.Armour.ArmourCoefficient);
            Console.SetCursorPosition(Console.WindowWidth - 11, 1);
            Console.Write("Health:{0}", secondPlayer.Spaceship.Health);
        }

        private void PrintHitted(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            int time = 100;
            while (time >= 0)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 2);
                Console.Write($"{firstPlayer.Name} hit {secondPlayer.Name} for {firstPlayer.Spaceship.Weapon.Power} damage");
                time--;
            }
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
                Thread.Sleep(35);
            }

            writer.WriteColorTextCenter($"{winnerName} wins!");
        }

        private void ManageShooting(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            if (firstPlayer.Spaceship.IsAtShooting)
            {
                //move first player bullet
                firstPlayer.Spaceship.Weapon.Bullet.PositionX += firstPlayer.Spaceship.Weapon.Speed;

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
                secondPlayer.Spaceship.Weapon.Bullet.PositionX -= secondPlayer.Spaceship.Weapon.Speed;

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
            else if(firstPlayer.Spaceship.Weapon.Model == "Plasma Weapon" || firstPlayer.Spaceship.Weapon.Model == "Cannon")
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
/*
|__xxxxxxxxxxxxxxxx__________________________________ |
|                1-0                  |y
|                                     |y
|                                     |y
||         *                         *|y
||                                   *|y
||                                   *|y
||                                   *|y
|                                     |
|                                     |
|                                     |
|                                     |
|                                     |
|_____________________________________|_
*/
