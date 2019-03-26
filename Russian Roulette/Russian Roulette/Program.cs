using System;
using System.Threading;

namespace RussianRoulette
{
    class Program
    {
        public static Random random = new Random();

        static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;


                TitleTextCrawl("Russian Roulette");

                TextCrawl("Welcome to Russian Roulette.");
                Thread.Sleep(1000);

                TextCrawl("The rules are simple. Each turn, you can choose to shoot yourself or your opponent.");
                Thread.Sleep(1000);

                TextCrawl("If you shoot your opponent and it doesn't fire, you have to shoot yourself.");
                Thread.Sleep(1000);

                TextCrawl("Once per game, you can respin the chamber and reset the bullet position.");
                Thread.Sleep(1000);

                TextCrawl("Good luck.");
                Thread.Sleep(3000);


            // These variables keep track of the position of the bullet's chamber and the current chamber.
            int Chamber = 1;
            int BulletChamber = random.Next(1, 7);

            //Console.WriteLine("DEBUG: Chamber = {0}, BulletChamber = {1}", Chamber, BulletChamber);
            //Console.ReadKey(true);


            bool RespinUsed = false;    
            bool GameOver = false;
            int Round = 1;
            string turn = "player";

            while (!GameOver)
            {

                if (turn == "player")
                {
                    Console.Clear();
                    Console.WriteLine("ROUND " + Round);

                    TextCrawl("A - Shoot yourself || B - Shoot opponent ", 25, false);

                    if (!RespinUsed)
                    {
                        TextCrawl("|| C - Respin chamber ", 25, false);
                    }

                    TextCrawl("~~>>> ", 25, false);


                    string Choice = Console.ReadLine().ToLower();

                    if (Choice == "a")
                    {
                        if (Chamber != BulletChamber)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Thread.Sleep(100);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();

                            Console.Write("CLICK! ");
                            Thread.Sleep(1000);
                            TextCrawl("No bullet was fired.");
                            Thread.Sleep(3000);

                            Chamber++;
                            Round++;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(3000);
                            Console.BackgroundColor = ConsoleColor.Black;   
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            TextCrawl("You are dead. You shot yourself on round " + Round + ".");
                            Thread.Sleep(5000);

                            GameOver = true;
                        }
                    }

                    else if (Choice == "b")
                    {
                        if (Chamber != BulletChamber)
                        {
                            Console.Write("CLICK! ");
                            Thread.Sleep(1000);
                            TextCrawl("No bullet was fired - you must now shoot yourself.");
                            Thread.Sleep(3000);

                            Chamber++;

                            if (Chamber != BulletChamber)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Thread.Sleep(100);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();

                                Console.Write("CLICK! ");
                                Thread.Sleep(1000);
                                TextCrawl("No bullet was fired.");
                                Thread.Sleep(3000);

                                Chamber++;
                                Round++;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("BANG!");
                                Thread.Sleep(3000);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                Console.WriteLine("BANG!");
                                TextCrawl("You are dead. You shot yourself on round " + Round + ".");
                                Thread.Sleep(5000);

                                GameOver = true;
                            }
                        } else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(3000);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            TextCrawl("Your opponent is dead. You shot them on round " + Round + ".");
                            Thread.Sleep(5000);

                            GameOver = true;
                        }
                    }

                    else if (Choice == "c" && !RespinUsed)
                    {
                        Console.Clear();
                        RespinUsed = true;

                        TextCrawl("Respinning the chamber.");
                        Thread.Sleep(1000);

                        BulletChamber = random.Next(1, 7);
                        Chamber = 1;
                        TextCrawl("Bullet position has been randomized.");
                        Thread.Sleep(3000);

                        Round++;
                    }
                    else
                    {
                        TextCrawl("Invalid choice.");
                        Thread.Sleep(3000);
                    }

                    turn = "computer";

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ROUND " + Round);
                    Console.WriteLine("Computer's turn.");
                    int ComputerChoice = random.Next(1, 3);
                    Thread.Sleep(3000);
                    Console.Clear();

                    if (ComputerChoice == 1)
                    {
                        TextCrawl("Computer has chosen to shoot itself.");
                        Thread.Sleep(2000);
                        Console.Clear();

                        if (Chamber != BulletChamber)
                        {
                            Console.Write("CLICK! ");
                            Thread.Sleep(1000);
                            TextCrawl("No bullet was fired.");
                            Thread.Sleep(3000);

                            Chamber++;
                            Round++;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(3000);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            TextCrawl("Your opponent is dead. They shot themselves on round " + Round + ".");
                            Thread.Sleep(5000);

                            GameOver = true;
                        }

                    } else
                    {
                        TextCrawl("Computer has chosen to shoot you.");
                        Thread.Sleep(2000);

                        if (Chamber != BulletChamber)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Thread.Sleep(100);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Clear();

                            Console.Write("CLICK! ");
                            Thread.Sleep(1000);
                            TextCrawl("No bullet was fired - They must now shoot themselves.");
                            Thread.Sleep(3000);

                            Chamber++;

                            if (Chamber != BulletChamber)
                            {
                                Console.Write("CLICK! ");
                                Thread.Sleep(1000);
                                TextCrawl("No bullet was fired.");
                                Thread.Sleep(3000);

                                Chamber++;
                                Round++;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("BANG!");
                                Thread.Sleep(3000);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                Console.WriteLine("BANG!");
                                TextCrawl("Your opponent is dead. They shot themselves on round " + Round + ".");
                                Thread.Sleep(5000);

                                GameOver = true;
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(3000);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            TextCrawl("You are dead. Your opponent shot you on round " + Round + ".");
                            Thread.Sleep(5000);

                            GameOver = true;
                        }
                    }


                    Round++;
                    turn = "player";
                }
            }

            TextCrawl("Play again? press Y or N", 50, false);
            var PlayAgain = Console.ReadKey(true);

            if (PlayAgain.Key == ConsoleKey.Y)
            {
                Main();
            } else
            {
                Environment.Exit(0);
            }

        }


        public static void TextCrawl(string str, int ms = 50, bool endl = true)
        {
            char[] chars = str.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
                Thread.Sleep(ms);
            }

            if (endl) Console.WriteLine();
        }


        public static void TitleTextCrawl(string str, int ms = 150)
        {
            string title = "";
            char[] chars = str.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                title += chars[i];
                Console.Title = title;
                Thread.Sleep(ms);
            }
        }
    }
}