using SpaceshipsBattle.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceshipsBattle.Core.GameController
{
    public class GameController
    {
        //static int ballPositionX = 0;
        //static int ballPositionY = 0;

        static Player firstPlayer = new Player();
        static Player secondPlayer = new Player();



        static void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }


        static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
        static void DrawFirstPlayer()
        {
            for (int i = firstPlayer.Spaceship.PositionY; i < firstPlayer.Spaceship.PositionY + 4; i++)
            {
                for (int j = 0; j < i - firstPlayer.Spaceship.PositionY; j++)
                {
                    PrintAtPosition(j, i, '*');

                }
            }

            // PrintAtPosition(0, firstPlayer.PositionY + 3, '|');

        }

        static void DrawSecondPlayer()
        {
            PrintAtPosition(Console.WindowWidth - 1, secondPlayer.Spaceship.PositionY, '|');

        }

        static void SetInitialPositions()
        {
            firstPlayer.Spaceship.PositionY = Console.WindowHeight / 2;
            secondPlayer.Spaceship.PositionY = Console.WindowHeight / 2;
        }

        static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, '@');
        }

        static void PrintResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.Write("{0}-{1}", firstPlayer.Result, secondPlayer.Result);
        }

        static void PrintHitted()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 2);
            Console.Write("Hitted");
        }


        static void MoveFirstPlayerDown()
        {
            if (firstPlayer.PositionY < Console.WindowHeight - 5)
            {
                firstPlayer.PositionY++;
            }
        }

        static void MoveFirstPlayerUp()
        {
            if (firstPlayer.PositionY > 0)
            {
                firstPlayer.PositionY--;
            }
        }

        static void MoveSecondPlayerDown()
        {
            if (secondPlayer.PositionY < Console.WindowHeight - 1)
            {
                secondPlayer.PositionY += 2;
            }
        }

        static void MoveSecondPlayerUp()
        {
            if (secondPlayer.PositionY > 1)
            {
                secondPlayer.PositionY -= 2;
            }
        }

        static void FireFirstPlayer()
        {
            ballPositionY = firstPlayer.positionAtTheMomentOfShooting;
            ballPositionX++;
        }
        static void Main(string[] args)
        {
            RemoveScrollBars();
            SetInitialPositions();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.W)
                    {
                        MoveFirstPlayerUp();
                    }
                    if (keyInfo.Key == ConsoleKey.S)
                    {
                        MoveFirstPlayerDown();
                    }
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        MoveSecondPlayerUp();
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        MoveSecondPlayerDown();
                    }
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {

                    }
                    //Shoot first player
                    if (keyInfo.Key == ConsoleKey.Q)
                    {
                        if (firstPlayer.IsOnFire != true)
                        {
                            firstPlayer.positionAtTheMomentOfShooting = firstPlayer.PositionY;
                            firstPlayer.Bullet.PositionX = 1;
                            firstPlayer.IsOnFire = true;
                        }

                    }
                    if (keyInfo.Key == ConsoleKey.D0)
                    {
                        if (secondPlayer.IsOnFire != true)
                        {
                            secondPlayer.positionAtTheMomentOfShooting = secondPlayer.PositionY;
                            secondPlayer.Bullet.PositionX = Console.WindowWidth - 1;
                            secondPlayer.IsOnFire = true;
                        }

                    }
                }
                if (firstPlayer.IsOnFire == true)
                {
                    firstPlayer.Bullet.PositionY = firstPlayer.positionAtTheMomentOfShooting;

                    firstPlayer.FireInTheHole();

                    //hit
                    if (firstPlayer.Bullet.PositionX >= Console.WindowWidth - 8)
                    {
                        if (firstPlayer.Bullet.PositionY == secondPlayer.PositionY)
                        {
                            firstPlayer.Result++;
                            PrintHitted();
                        }
                    }


                }

                if (secondPlayer.IsOnFire == true)
                {
                    secondPlayer.Bullet.PositionY = secondPlayer.positionAtTheMomentOfShooting;

                    secondPlayer.Bullet.PositionX -= 5;

                    if (secondPlayer.Bullet.PositionX - 5 <= 0)
                    {
                        secondPlayer.IsOnFire = false;
                    }

                    //hit
                    if (secondPlayer.Bullet.PositionX <= 8)
                    {
                        if (secondPlayer.Bullet.PositionY == firstPlayer.PositionY)
                        {
                            secondPlayer.Result++;
                        }
                        PrintHitted();

                    }

                }
                Console.Clear();
                DrawFirstPlayer();

                DrawSecondPlayer();
                if (firstPlayer.IsOnFire)
                {
                    PrintAtPosition(firstPlayer.Bullet.PositionX, firstPlayer.Bullet.PositionY, 'A');

                }
                if (secondPlayer.IsOnFire)
                {
                    PrintAtPosition(secondPlayer.Bullet.PositionX, secondPlayer.Bullet.PositionY, 'B');

                }

                PrintResult();
                Thread.Sleep(30);
            }
        }
        //Alex da napishe tuk logikata za damage done
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
