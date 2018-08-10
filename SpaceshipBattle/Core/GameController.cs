﻿using SpaceshipBattle.Contracts;
using System;
using System.Threading;

namespace SpaceshipBattle.Core
{
    public class GameController
    {
        //TODO implement IGameController
        public GameController()
        {

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

                ManageShooting(firstPlayer, secondPlayer);

                Console.Clear();

                DrawShip.DrawShipPlayerOne(firstPlayer);
                DrawShip.DrawShipPlayerTwo(secondPlayer);

                DrawBullet(firstPlayer, 'A');
                DrawBullet(secondPlayer, 'B');


                PrintResult(firstPlayer, secondPlayer);
                Thread.Sleep(30);
            }
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
            if (firstPlayer.Spaceship.Weapon.Bullet.PositionY == secondPlayer.Spaceship.PositionY)
            {
                firstPlayer.Spaceship.TakeDamageToPlayer(secondPlayer);
                PrintHitted();
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
