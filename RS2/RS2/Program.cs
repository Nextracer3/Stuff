using System;
using System.Threading;
using System.Media;
using System.IO;

namespace RussianRoulette2
{
    class Program
    {
        public static Random rnd = new Random();
        public static SoundPlayer Snd = new SoundPlayer();

        static void Main()
        {
            string[] SoundIndex = { "Intense.wav", "Intense2.wav", "Intense3.wav" };
            try    // Try catch as the sound location is only on my PC
            {
                Snd.SoundLocation = SoundIndex[rnd.Next(SoundIndex.Length)];
                Snd.PlayLooping();
            }
            catch (IOException)
            {

            }

            Console.CursorVisible = false;

            // Intro
            Console.Clear();
            TitleTextCrawl("Russian Roulette");
            Thread.Sleep(1000);

            TextCrawl("Welcome to Russian Roulette.");
            Thread.Sleep(1000);

            TextCrawl("The rules are simple.");
            Thread.Sleep(1000);

            TextCrawl("A bullet will be placed in one of six chambers at random.");
            Thread.Sleep(1000);

            TextCrawl("Each turn, you can choose to either shoot yourself or your opponent.");
            Thread.Sleep(1000);

            TextCrawl("If you shoot your opponent and it doesn't fire, you must then shoot yourself.");
            Thread.Sleep(1000);

            TextCrawl("Once per game, you may choose to respin the cylinder and reset the bullet position.");
            Thread.Sleep(1000);

            TextCrawl("Good luck.");
            Thread.Sleep(3000);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);

            // Get user input to select gamemode
            while (true)
            {
                Console.Clear();
                TextCrawl("1 -- Player vs Computer || 2 -- Player vs Player ~~>>> ", 50, false);
                string Choice = Console.ReadLine();


                if (Choice == "1")
                {
                    PvC();
                }

                else if (Choice == "2")
                {
                    PvP();
                }

                else
                {
                    TextCrawl("Invalid.");
                    Thread.Sleep(1000);
                }
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


        // It may seem like this function is useless and obsolete
        // And that would be correct
        // But for some reason it breaks the whole program if it is removed
        // So it is here to stay
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




        public static void PvC()
        {
            Console.Clear();

            int BulletChamber = rnd.Next(1, 7);     
            int CurrentChamber = 1;                
            bool GameOver = false;
            int Round = 1;
            bool RespinUsed = false;
            string turn = "player";

            // Game loop
            while (!GameOver)
            {
                if (turn == "player")
                {
                    Console.Clear();
                    Console.WriteLine("ROUND " + Round + " -- YOUR TURN");
                    Thread.Sleep(1000);

                    TextCrawl("A -- Shoot yourself || B -- Shoot opponent", 25, false);
                    if (!RespinUsed) { TextCrawl(" || C -- Respin cylinder", 25, false); }
                    TextCrawl(" ~~>>> ", 25, false);

                    string PlayerChoice = Console.ReadLine();
                    Console.Clear();

                    if (PlayerChoice.ToLower() == "a")
                    {
                        if (CurrentChamber != BulletChamber)
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

                            CurrentChamber++;
                            Round++;
                            turn = "computer";
                        } 
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(2000);

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            TextCrawl("You are dead. You shot yourself on round " + Round + ".");
                            Thread.Sleep(3000);
                            GameOver = true;
                        }
                    }

                    else if (PlayerChoice.ToLower() == "b")
                    {
                        if (CurrentChamber != BulletChamber)
                        {
                            Console.Write("CLICK! ");
                            Thread.Sleep(1000);
                            TextCrawl("No bullet was fired - you must now shoot yourself...");
                            Thread.Sleep(3000);

                            CurrentChamber++;

                            if (CurrentChamber != BulletChamber)
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

                                CurrentChamber++;
                                Round++;
                                turn = "computer";
                            }

                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("BANG!");
                                Thread.Sleep(2000);

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                Console.WriteLine("BANG!");
                                TextCrawl("You are dead. You shot yourself on round " + Round + ".");
                                Thread.Sleep(3000);
                                GameOver = true;
                            }
                        }

                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(2000);

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            TextCrawl("Your opponent is dead. You shot them on round " + Round + ".");
                            Thread.Sleep(3000);
                            GameOver = true;
                        }
                    }

                    else if (PlayerChoice.ToLower() == "c" && !RespinUsed)
                    {
                        TextCrawl("Respinning the cylinder.");
                        BulletChamber = rnd.Next(1, 7);
                        CurrentChamber = 1;

                        Thread.Sleep(1000);
                        TextCrawl("Cylinder has been randomized.");
                        Thread.Sleep(2000);

                        Round++;
                        RespinUsed = true;  
                        turn = "computer";
                    }

                    else
                    {
                        TextCrawl("Invalid selection.");
                        Thread.Sleep(2000);

                        Round++;
                        turn = "computer";
                    }
                }

                // Computer turn
                else
                {
                    Console.Clear();
                    Console.WriteLine("ROUND " + Round + " -- COMPUTER'S TURN");
                    Thread.Sleep(1000);

                    TextCrawl("Computer is making a selection.");
                    Thread.Sleep(3000);    // Just for suspense

                    int ComputerChoice = rnd.Next(1, 3);

                    if (ComputerChoice == 1)
                    {
                        Console.Clear();
                        TextCrawl("Computer has chosen to shoot itself.");
                        Thread.Sleep(2000);

                        if (CurrentChamber != BulletChamber)
                        {
                            Console.Clear();
                            Console.Write("CLICK! ");
                            Thread.Sleep(1000);
                            TextCrawl("No bullet was fired.");
                            Thread.Sleep(2000);

                            CurrentChamber++;
                            Round++;
                            turn = "player";
                        }

                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();

                            Console.WriteLine("BANG!");
                            Thread.Sleep(2000);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.WriteLine("BANG!");

                            TextCrawl("Your opponent is dead. They shot themselves on round " + Round + ".");
                            Thread.Sleep(3000);
                            GameOver = true;
                        }
                    }

                    else if (ComputerChoice == 2)
                    {
                        Console.Clear();
                        TextCrawl("Computer has chosen to shoot you.");
                        Thread.Sleep(2000);

                        if (CurrentChamber != BulletChamber)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Thread.Sleep(100);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();

                            Console.Write("CLICK! ");
                            Thread.Sleep(1000);
                            TextCrawl("No bullet was fired - they must now shoot themselves...");
                            Thread.Sleep(3000);

                            CurrentChamber++;

                            if (CurrentChamber != BulletChamber)
                            {
                                Console.Clear();
                                Console.Write("CLICK! ");
                                Thread.Sleep(1000);
                                TextCrawl("No bullet was fired.");
                                Thread.Sleep(3000);

                                CurrentChamber++;
                                Round++;
                                turn = "player";
                            }

                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("BANG!");
                                Thread.Sleep(2000);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                Console.WriteLine("BANG!");

                                TextCrawl("Your opponent is dead. They shot themselves on round " + Round + ".");
                                Thread.Sleep(3000);
                                GameOver = true;
                            }
                        }

                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(2000);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.WriteLine("BANG!");

                            TextCrawl("You are dead. Your opponent shot you on round " + Round + ".");
                            Thread.Sleep(3000);
                            GameOver = true;
                        }
                    }
                }
            }


            // Game over

            Console.Clear();
            TextCrawl("Would you like to play again?");
            TextCrawl("1 -- Player vs Computer || 2 -- Player vs Player || 3 -- Exit ~~>>> ", 50, false);

            string PlayAgain = Console.ReadLine();

            if (PlayAgain == "1") { PvC(); }
            if (PlayAgain == "2") { PvP(); }

            Environment.Exit(0);
        }





        public static void PvP()
        {
            Console.Clear();
            TextCrawl("Enter Player 1's name ~~>>> ", 50, false);
            string Player1Name = Console.ReadLine();

            TextCrawl("Enter Player 2's name ~~>>> ", 50, false);
            string Player2Name = Console.ReadLine();

            Console.Clear();
            Console.Write(Player1Name);
            Thread.Sleep(1000);
            Console.Write("        VS");
            Thread.Sleep(1000);
            Console.Write("        {0}", Player2Name);
            Thread.Sleep(3000);

            int BulletChamber = rnd.Next(1, 7);
            int CurrentChamber = 1;
            bool GameOver = false;
            bool P1RespinUsed = false;
            bool P2RespinUsed = false;
            int Round = 1;
            string[] TurnIndex = { "player1", "player2" };
            string turn = TurnIndex[rnd.Next(TurnIndex.Length)];    // Randomly select player to start


            //Game loop
            while (!GameOver)
            {
                //Player 1 turn
                if (turn == "player1")
                {
                    Console.Clear();
                    Console.WriteLine("ROUND {0} -- {1}'S TURN", Round, Player1Name.ToUpper());
                    Thread.Sleep(1000);

                    TextCrawl("A -- Shoot yourself || B -- Shoot opponent ", 25, false);
                    if (!P1RespinUsed) { TextCrawl("|| C -- Respin cylinder ", 25, false); }
                    TextCrawl("~~>>> ", 25, false);

                    string Player1Choice = Console.ReadLine();
                    Console.Clear();

                    if (Player1Choice.ToLower() == "a")
                    {
                        if (CurrentChamber != BulletChamber)
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

                            CurrentChamber++;
                            Round++;
                            turn = "player2";
                        }

                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(2000);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("{0} is dead. They shot themselves on round {1}", Player1Name, Round);
                            Thread.Sleep(3000);
                            GameOver = true;    
                        }
                    }

                    else if (Player1Choice.ToLower() == "b")
                    {
                        if (CurrentChamber != BulletChamber)
                        {
                            Console.Write("CLICK! ");
                            Thread.Sleep(1000);
                            TextCrawl("No bullet was fired - you must now shoot yourself...");
                            Thread.Sleep(3000);

                            if (CurrentChamber != BulletChamber)
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

                                CurrentChamber++;
                                Round++;
                                turn = "player2";
                            }

                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("BANG!");
                                Thread.Sleep(2000);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write("{0} is dead. They shot themselves on round {1}", Player1Name, Round);
                                Thread.Sleep(3000);
                                GameOver = true;
                            }
                        }

                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(2000);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.WriteLine("BANG!");

                            TextCrawl(Player2Name + " is dead. They were shot by " + Player1Name + " on round " + Round + ".");
                            Thread.Sleep(3000);
                            GameOver = true;
                        }
                    }

                    else if (Player1Choice.ToLower() == "c" && !P1RespinUsed)
                    {
                        TextCrawl("Respinning the cylinder.");
                        Thread.Sleep(1000);

                        BulletChamber = rnd.Next(1, 7);
                        CurrentChamber = 1;
                        P1RespinUsed = true;

                        TextCrawl("Cylinder has been randomized.");
                        Thread.Sleep(2000);

                        Round++;
                        turn = "player2";
                    }

                    else
                    {
                        TextCrawl("Invalid selection.");
                        Thread.Sleep(2000);
                        Round++;
                        turn = "player2";
                    }
                }

                // Player 2 turn
                else
                {
                    Console.Clear();
                    Console.WriteLine("ROUND {0} -- {1}'S TURN", Round, Player2Name.ToUpper());
                    Thread.Sleep(1000);

                    TextCrawl("A -- Shoot yourself || B -- Shoot opponent ", 25, false);
                    if (!P2RespinUsed) { TextCrawl("|| C -- Respin cylinder ", 25, false); }
                    TextCrawl("~~>>> ", 25, false);

                    string Player2Choice = Console.ReadLine();
                    Console.Clear();

                    if (Player2Choice.ToLower() == "a")
                    {
                        if (CurrentChamber != BulletChamber)
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

                            CurrentChamber++;
                            Round++;
                            turn = "player1";
                        }

                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(2000);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("{0} is dead. They shot themselves on round {1}", Player2Name, Round);
                            Thread.Sleep(3000);
                            GameOver = true;
                        }
                    }

                    else if (Player2Choice.ToLower() == "b")
                    {
                        if (CurrentChamber != BulletChamber)
                        {
                            Console.Write("CLICK! ");
                            Thread.Sleep(1000);
                            TextCrawl("No bullet was fired - you must now shoot yourself...");
                            Thread.Sleep(3000);

                            if (CurrentChamber != BulletChamber)
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

                                CurrentChamber++;
                                Round++;
                                turn = "player1";
                            }

                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("BANG!");
                                Thread.Sleep(2000);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write("{0} is dead. They shot themselves on round {1}", Player2Name, Round);
                                Thread.Sleep(3000);
                                GameOver = true;
                            }
                        }

                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("BANG!");
                            Thread.Sleep(2000);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.WriteLine("BANG!");

                            TextCrawl(Player1Name + " is dead. They were shot by " + Player2Name + " on round " + Round + ".");
                            Thread.Sleep(3000);
                            GameOver = true;
                        }
                    }

                    else if (Player2Choice.ToLower() == "c" && !P2RespinUsed)
                    {
                        TextCrawl("Respinning the cylinder.");
                        Thread.Sleep(1000);

                        BulletChamber = rnd.Next(1, 7);
                        CurrentChamber = 1;
                        P2RespinUsed = true;

                        TextCrawl("Cylinder has been randomized.");
                        Thread.Sleep(2000);

                        Round++;
                        turn = "player1";
                    }

                    else
                    {
                        TextCrawl("Invalid selection.");
                        Thread.Sleep(2000);

                        Round++;
                        turn = "player1"; 
                    }
                }
            }


            // Game Over

            Console.Clear();
            TextCrawl("Would you like to play again?");
            TextCrawl("1 -- Player vs Computer || 2 -- Player vs Player || 3 -- Exit ~~>>> ", 50, false);

            string PlayAgain = Console.ReadLine();

            if (PlayAgain == "1") { PvC(); }
            if (PlayAgain == "2") { PvP(); }

            Environment.Exit(0);
        }
    }
}
