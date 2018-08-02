using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Core.Factories;
using SpaceshipBattle.Entities;
using SpaceshipsBattle.Contracts;
using SpaceshipsBattle.Contracts.Factories;
using SpaceshipsBattle.Core.Factories;
using SpaceshipsBattle.Entities;
using SpaceshipsBattle.Entities.Players;
using SpaceshipsBattle.Entities.Weapons;
using System;

namespace SpaceshipsBattle
{
    class StartUp
    {
        static IEngineFactory enginefactory = new EngineFactory();
        static IArmourFactory armourFactory = new ArmourFactory();

        static IEngine firstEngine = enginefactory.CreateEngine("TDI");
        static IArmour firstArmour = armourFactory.CreateArmour("Brick cage");
        static IWeapon firstWeapon = new Weapon("ak", 222, 22);
        static Spaceship firstPlShip = new Spaceship(firstEngine, firstArmour, firstWeapon );
        static Player firstPlayer = new Player("pesho",firstPlShip);
        static Bullet firstBullet = new Bullet();
        static Bullet secondBullet = new Bullet();


        static IEngine secondEngine = enginefactory.CreateEngine("TDI");
        static IArmour secondArmour = armourFactory.CreateArmour("Brick cage");
        static IWeapon secondWeapon = new Weapon("ak", 222, 22);
        static Spaceship secondPlShip = new Spaceship(secondEngine, secondArmour, secondWeapon);
        static Player secondPlayer = new Player("gosho", secondPlShip);
           
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
            Console.Write("{0}-{1}", firstPlayer.Spaceship.Health, secondPlayer.Spaceship.Health);
        }

        static void PrintHitted()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 2);
            Console.Write("Hitted");
        }


        static void MoveFirstPlayerDown()
        {
            if (firstPlayer.Spaceship.PositionY < Console.WindowHeight - 5)
            {
                firstPlayer.Spaceship.PositionY++;
            }
        }

        static void MoveFirstPlayerUp()
        {
            if (firstPlayer.Spaceship. PositionY > 0)
            {
                firstPlayer.Spaceship. PositionY--;
            }
        }

        static void MoveSecondPlayerDown()
        {
            if (secondPlayer.Spaceship. PositionY < Console.WindowHeight - 1)
            {
                secondPlayer.Spaceship. PositionY += secondPlayer.Spaceship.Speed;
            }
        }

        static void MoveSecondPlayerUp()
        {
            if (secondPlayer.Spaceship. PositionY > 1)
            {
                secondPlayer.Spaceship. PositionY -= secondPlayer.Spaceship.Speed;
            }
        }

        static void FireFirstPlayer()
        {
            firstBullet.PositionY = firstPlayer.posi;
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
                        if (firstPlayer.Spaceship.IsAtShooting != true)
                        {
                            firstPlayer.Spaceship.PositionAtTheMomentOfShooting = firstPlayer.Spaceship. PositionY;
                            firstBullet.PositionX = 1;
                            //firstPlayer.Spaceship.Weapon.Bullet.PositionX = 1;
                            firstPlayer.Spaceship.IsAtShooting = true;
                        }

                    }
                    if (keyInfo.Key == ConsoleKey.D0)
                    {
                        if (secondPlayer.Spaceship.IsAtShooting != true)
                        {
                            secondPlayer.Spaceship.PositionAtTheMomentOfShooting = firstPlayer.Spaceship.PositionY;
                            secondBullet.PositionX = 1;
                            //firstPlayer.Spaceship.Weapon.Bullet.PositionX = 1;
                            secondPlayer.Spaceship.IsAtShooting = true;
                        }

                    }
                }
                if (firstPlayer.Spaceship.IsAtShooting  == true)
                {
                    firstBullet.PositionY = firstPlayer.Spaceship.PositionAtTheMomentOfShooting;
                    //firstPlayer.Bullet.PositionY = firstPlayer.positionAtTheMomentOfShooting;

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
    }
}
