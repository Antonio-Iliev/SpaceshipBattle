using SpaceshipBattle.Contracts;
using System;
using System.Threading;

namespace SpaceshipBattle.Core
{
    public class GameController
    {
        public GameController()
        {
            
        }

        private void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        private void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        private void DrawFirstPlayer(IPlayer player)
        {
            PrintAtPosition(0, player.Spaceship. PositionY , '|');
        }

        private void DrawSecondPlayer(IPlayer player)
        {
            PrintAtPosition(Console.WindowWidth - 1, player.Spaceship.PositionY, '|');
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
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.Write("{0}-{1}", firstPlayer.Spaceship.Health, secondPlayer.Spaceship.Health);
        }

        private void PrintHitted()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 2);
            Console.Write("Hitted");
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

                if (firstPlayer.Spaceship.IsAtShooting == true)
                {
                    firstPlayer.Spaceship.Weapon.Bullet.PositionY = firstPlayer.Spaceship.PositionAtTheMomentOfShooting;

                    firstPlayer.Spaceship.Shoot("left");

                    HitPlayer(firstPlayer, secondPlayer);
                }

                if (secondPlayer.Spaceship.IsAtShooting == true)
                {
                    secondPlayer.Spaceship.Weapon.Bullet.PositionY = secondPlayer.Spaceship.PositionAtTheMomentOfShooting;

                    // secondPlayer.Spaceship.Shoot("right");
                    secondPlayer.Spaceship.Weapon.Bullet.PositionX -= 3;
                    if (secondPlayer.Spaceship.Weapon.Bullet.PositionX - 3 <= 0)
                    {
                        secondPlayer.Spaceship.IsAtShooting = false;
                    }

                    //hit
                    HitPlayer(firstPlayer, secondPlayer);

                }
                Console.Clear();

                DrawFirstPlayer(firstPlayer);
                DrawSecondPlayer(secondPlayer);

                DrawFirstPlayerBullet(firstPlayer);
                DrawSecondPlayerBullet(secondPlayer);

                PrintResult(firstPlayer, secondPlayer);
                Thread.Sleep(30);
            }
        }

        private void DrawSecondPlayerBullet(IPlayer secondPlayer)
        {
            if (secondPlayer.Spaceship.IsAtShooting)
            {
                PrintAtPosition(secondPlayer.Spaceship.Weapon.Bullet.PositionX, secondPlayer.Spaceship.Weapon.Bullet.PositionY, 'B');
            }
        }

        private void DrawFirstPlayerBullet(IPlayer firstPlayer)
        {
            if (firstPlayer.Spaceship.IsAtShooting)
            {
                PrintAtPosition(firstPlayer.Spaceship.Weapon.Bullet.PositionX, firstPlayer.Spaceship.Weapon.Bullet.PositionY, 'A');
            }
        }

        private void HitPlayer(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            if (firstPlayer.Spaceship.Weapon.Bullet.PositionX >= Console.WindowWidth - 3)
            {
                if (firstPlayer.Spaceship.Weapon.Bullet.PositionY == secondPlayer.Spaceship.PositionY)
                {
                    secondPlayer.Spaceship.TakeDamage(firstPlayer.Spaceship.Weapon.Damage);
                    PrintHitted();
                }
            }

            if (secondPlayer.Spaceship.Weapon.Bullet.PositionX <= 3)
            {
                if (secondPlayer.Spaceship.Weapon.Bullet.PositionY == firstPlayer.Spaceship.PositionY)
                {
                    firstPlayer.Spaceship.TakeDamage(secondPlayer.Spaceship.Weapon.Damage);
                    PrintHitted();
                }
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
