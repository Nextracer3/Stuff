using System;
using System.Threading;
using System.Media;
using System.Linq;
using System.Diagnostics;
using WMPLib;

namespace RPG
{
    class Program
    {
        
        static void Main(string[] cmdLineArgs)
        {
            Console.CursorVisible = false;

            SetCol(ConsoleColor.Blue);
            TitleTextCrawl("Super epic RPG (tm)");
            Sounds.PlayLooping("Despacito.wav");
            TextCrawl("(c) 2019 Harry Waddle, all rights reserved\n");
            TextCrawl("Some flashing lights, so cover your eyes I guess");

            if (cmdLineArgs.Length > 0) { Console.WriteLine("ARGS: {0}", cmdLineArgs); }

            Thread.Sleep(3000);

            Menu();

            Console.Clear();
            TextCrawl("What is your name? ~~>>> ", 50, false);
            string Name = Console.ReadLine();
            TextCrawl("Noice.");
            Thread.Sleep(2000);

            Prologue(Name);
        }


        public static void Menu()
        {
            Console.Clear();
            SetCol(ConsoleColor.Blue);
            TextCrawl(" START \n GITHUB PAGE \n EXIT ");
            Console.Clear();
            SetCol(ConsoleColor.Cyan);

            string selected = "start";
            bool BreakWhile = false;

            Console.WriteLine("-START-\n GITHUB PAGE \n EXIT ");

            while (!BreakWhile)
            {
                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:

                        if (selected != "start")
                        {
                            if (selected == "github")
                            {
                                selected = "start";
                                Console.Clear();
                                Console.WriteLine("-START-\n GITHUB PAGE \n EXIT ");
                            }

                            else if (selected == "exit")
                            {
                                selected = "github";
                                Console.Clear();
                                Console.WriteLine(" START \n-GITHUB PAGE-\n EXIT ");
                            }
                        }

                        break;

                    case ConsoleKey.DownArrow:

                        if (selected != "exit")
                        {
                            if (selected == "start")
                            {
                                selected = "github";
                                Console.Clear();
                                Console.WriteLine(" START \n-GITHUB PAGE-\n EXIT ");
                            }

                            else if (selected == "github")
                            {
                                selected = "exit";
                                Console.Clear();
                                Console.WriteLine(" START \n GITHUB PAGE \n-EXIT-");
                            }
                        }

                        break;

                    case ConsoleKey.Enter:

                        if (selected == "start") { BreakWhile = true; }

                        else if (selected == "github")
                        {
                            Process.Start("Chrome.exe", "https://www.github.com/Nextracer3/stuff");
                        }

                        else { Environment.Exit(0); }

                        break;
                }
            }
        }

        
        public static void Prologue(string Name)
        {
            string Brief = "\n\n--------------------\n---FOOD ISLE---\n\nThere is a can of soup in front of you. ('can')\nIt is guarded by an employee.\n\nAll directions are blocked as your mum is watching over you.\n\nOBJECTIVE: Get the can of soup\n\nITEMS: None\n--------------------";
            string Objective = "Pick up the can using the command 'get soup'";
            string[] items = { };


            SetCol(ConsoleColor.White, "back");
            Console.Clear();
            Thread.Sleep(500);
            SetCol(ConsoleColor.Gray, "back");
            Console.Clear();
            Thread.Sleep(500);
            SetCol(ConsoleColor.DarkGray, "back");
            Console.Clear();
            Thread.Sleep(500);
            SetCol(ConsoleColor.Black, "back");
            Console.Clear();
            Thread.Sleep(500);

            Sounds.FadeOut(40, 50);

            Sounds.PlayLooping("ShopAmbience.wav", 60);
            Thread.Sleep(6000);

            TextCrawl(Name + "?");
            Thread.Sleep(2000);
            Console.WriteLine("(press a key to continue dialogue)");
            AwaitKey();
            TextCrawl("You look up at your mum.");
            AwaitKey();
            TextCrawl("\nYOU: yea m8?");
            AwaitKey();
            TextCrawl("MUM: Can you pick up that can over there? I'll give you a chocolate bar if you do.");
            AwaitKey();
            TextCrawl("YOU: no");
            AwaitKey();
            TextCrawl("MUM: please");
            AwaitKey();
            TextCrawl("YOU: no");
            AwaitKey();
            TextCrawl("MUM: please");
            AwaitKey();
            TextCrawl("YOU: no");
            AwaitKey();

            TextCrawl("MUM: please");
            AwaitKey();
            TextCrawl("YOU: ok");
            AwaitKey();

            TextCrawl("\n\nPick up the can using the 'get' command.");
            TextCrawl("The ID of the item (the thing you need to type to pick it up) is displayed in brackets.");

            Console.ReadKey(true);

            DisplayNewObjective("GET THE CAN USING THE COMMAND 'GET CAN'");
            SetCol(ConsoleColor.DarkGreen);
            Console.WriteLine(Brief);
            SetCol(ConsoleColor.Cyan);

            Thread.Sleep(5000);

            TextCrawl("^^^ That is a brief. It is info about an area that is displayed when you enter it.");
            TextCrawl("You can see it at any time by typing 'brief.'");

            while (true)
            {
                SetCol(ConsoleColor.Blue);
                TextCrawl("\n~~>>> ", 50, false);
                SetCol(ConsoleColor.Cyan);

                string action = Console.ReadLine();

                if (action.ToLower() == "brief")
                {
                    SetCol(ConsoleColor.DarkGreen);
                    Console.WriteLine(Brief);
                    SetCol(ConsoleColor.Cyan);
                }

                else if (action.ToLower() == "get can")
                {
                    break;
                }
            }

            Console.Clear();
            SetCol(ConsoleColor.Magenta);
            TextCrawl("Objective completed.");
            SetCol(ConsoleColor.Cyan);

            TextCrawl("\nEMPLOYEE: OI!");
            AwaitKey();
            TextCrawl("YOU: What?");
            AwaitKey();
            TextCrawl("EMPLOYEE: YOU TOOK ME HECKIN SOUP LAD!");
            AwaitKey();
            TextCrawl("Mum jumps to your defence.");
            AwaitKey();
            TextCrawl("MUM: It's ours now m8");
            AwaitKey();
            TextCrawl("EMPLOYEE: BOI WHAT?");
            AwaitKey();
            TextCrawl("EMPLOYEE: *into mic* GET ME SECURITY GUY STEVE IN THE FOOD ISLE! THIS HECKIN HECK THINKS HE CAN JUST SHAMELESSLY TAKE ME HECKIN SOUP!");
            AwaitKey();
            TextCrawl("MUM: " + Name + ", Take the employee. I have Steve.");
            AwaitKey();

            Encounter("Employee", Name, 30, 100, true, true);    
        }


        public static void Encounter(string EnemyName, string PlayerName, int EnemyHealth, int PlayerHealth, bool FirstStrike, bool Tutorial)  // Encounter system
        {
            Sounds.PlayLooping("Encounter.wav");
            Sounds.SndPlayer.controls.currentPosition = 0.5;
            Console.Clear();

            Thread TitleTextCrawlThread = new Thread(() => TitleTextCrawl("ENCOUNTER!!!", 150));
            TitleTextCrawlThread.Start();

            for (int i = 0; i < 12; i++)
            {
                SetCol(ConsoleColor.Red, "back");
                Console.Clear();
                Thread.Sleep(100);
                SetCol(ConsoleColor.Black, "back");
                Console.Clear();
                Thread.Sleep(100);
            }

            int DmgMod = 0;
            int HpMod = 0;


            SetCol(ConsoleColor.Red);
            TextCrawl("A WILD " + EnemyName.ToUpper() + " APPEARED!");

            string turn = "enemy";

            if (FirstStrike)
            {
                turn = "player";
                DmgMod = 10;
            }


            if (Tutorial)   // Tutorial encounter
            {
                Thread.Sleep(1000);

                TextCrawl("FIRST STRIKE!");
                SetCol(ConsoleColor.Green);
                TextCrawl("\nYou have the first strike, as you started the battle first.");
                TextCrawl("This means you get the first turn and have an attack bonus for the first turn.");
                Thread.Sleep(3000);

                while (true)
                {
                    Console.Clear();
                    TextCrawl("It is your turn. Take advantage of your first strike and attack the enemy!");
                    TextCrawl("Attack by typing 'attack'.");

                    SetCol(ConsoleColor.Red);
                    Console.WriteLine("\n{0}'s HEALTH: {1}\nYOUR HEALTH: {2}\n\n", EnemyName, EnemyHealth, PlayerHealth);
                    SetCol(ConsoleColor.DarkYellow);
                    TextCrawl("~~>>>", 50, false);
                    SetCol(ConsoleColor.Red);

                    string action = Console.ReadLine();

                    if (action.ToLower() != "attack")
                    {
                        SetCol(ConsoleColor.Green);
                        TextCrawl("Try again -- attack the enemy by typing 'attack'.");
                        Thread.Sleep(1000);
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("{0} ATTACKS!", PlayerName.ToUpper());
                        Thread.Sleep(2000);

                        Console.Clear();
                        Console.WriteLine("10 DAMAGE");
                        Thread.Sleep(1000);

                        Console.Clear();
                        Console.WriteLine("10 DAMAGE + FIRST STRIKE");
                        Thread.Sleep(1000);

                        Console.Clear();
                        Console.WriteLine("10 DAMAGE + 5");
                        Thread.Sleep(1000);

                        Console.Clear();
                        Console.WriteLine("15 DAMAGE");
                        Thread.Sleep(2000);

                        SetCol(ConsoleColor.Red, "back");
                        Console.Clear();
                        Thread.Sleep(100);
                        SetCol(ConsoleColor.Black, "back");
                        Console.Clear();

                        TextCrawl("Employee was hit for 15 damage!");
                        break;
                    }
                }

                TextCrawl("\n\n\nWould be other stuff");
            }




            else  // Normal encounter
            {
                
            }
        }


        public static void DisplayNewObjective(string obj)
        {
            SetCol(ConsoleColor.Magenta);
            TextCrawl("\n---NEW OBJECTIVE---");
            Thread.Sleep(1000);
            SetCol(ConsoleColor.Green);
            TextCrawl(obj);
            SetCol(ConsoleColor.Cyan);
            Thread.Sleep(1000);
            Console.WriteLine();
        }

        public static void AwaitKey()
        {
            Console.ReadKey(true);
        }

        public static void TextCrawl(string str, int ms = 50, bool endl = true)
        {
            char[] chars = str.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
                Thread.Sleep(ms);
            }

            if (endl) Console.WriteLine();      // Leave a new line if endl is true
        }


        public static void TitleTextCrawl(string str, int ms = 150)
        {
            char[] chars = str.ToCharArray();
            string title = "";

            for (int i = 0; i < chars.Length; i++)
            {
                title += chars[i];
                Console.Title = title;
                Thread.Sleep(ms);
            }
        }


        public static void SetCol(ConsoleColor colour, string ground = "fore")      // Because I will be changing colours a lot
        {
            if (ground == "fore")
            {
                Console.ForegroundColor = colour;
            }
            else
            {
                Console.BackgroundColor = colour;
            }
        }
    }

    public class Sounds
    {
        public static WindowsMediaPlayer SndPlayer = new WindowsMediaPlayer();

        public static void Play(string file, int vol = 40)
        {
            SndPlayer.URL = file;
            SndPlayer.settings.volume = vol;
            SndPlayer.controls.play();
        }

        public static void PlayLooping(string file, int vol = 40)
        {
            SndPlayer.URL = file;
            SndPlayer.settings.volume = vol;
            SndPlayer.settings.setMode("loop", true);
            SndPlayer.controls.play();
        }

        public static void Stop()
        {
            SndPlayer.controls.stop();
        }

        public static void FadeOut(int curvol, int speed = 50)
        {
            for (int i = 0; i <= curvol; i++)
            {
                SndPlayer.settings.volume -= 1;
                Thread.Sleep(speed);
            }
        }
    }
}