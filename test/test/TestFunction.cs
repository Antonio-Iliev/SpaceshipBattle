using System;
using System.Threading;

namespace test
{
    class Program
    {
        static int positionYSelect = 0;
        static string text1 = "Weapon";
        static string text2 = "Engine";
        static string text3 = "Armor";

        static void Main(string[] args)
        {
            //Set Console
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetWindowSize(120, 35);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;



            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (positionYSelect > 0)
                        {
                            positionYSelect--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (positionYSelect < 2)
                        {
                            positionYSelect++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        switch (positionYSelect)
                        {
                            case 0:
                                DrawResult(text1);
                                break;
                            case 1:
                                DrawResult(text2);
                                break;
                            case 2:
                                DrawResult(text3);
                                break;
                            default:
                                break;
                        }
                        Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                        Thread.Sleep(5000);
                    }
                }
                

                DrawLine1(text1);
                DrawLine2(text2);
                DrawLine3(text3);
                
                //скриване на курсура
                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

                Thread.Sleep(100);
                Console.Clear();
            }
        }

        static void DrawLine1(string line)
        {
            Console.SetCursorPosition(0, 0);
            if (positionYSelect == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(line + " >>>>>");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else { Console.Write(line); }
        }

        static void DrawLine2(string line)
        {
            Console.SetCursorPosition(0, 1);
            if (positionYSelect == 1)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(line + " >>>>>");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else { Console.Write(line); }

        }

        static void DrawLine3(string line)
        {
            Console.SetCursorPosition(0, 2);
            if (positionYSelect == 2)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(line + " >>>>>");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else { Console.Write(line); }

        }

        static void DrawResult(string text) {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.Write(text);
        }
    }
}
