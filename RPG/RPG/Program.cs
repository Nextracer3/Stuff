using System;
using System.Threading;
using System.Media;
using System.Linq;
using System.Diagnostics;
using WMPLib;
using System.Collections.Generic;

namespace RPG
{
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] cmdLineArgs)
        {
            Console.CursorVisible = false;


            SetCol(ConsoleColor.Blue);
            TitleTextCrawl("Super epic RPG (tm)");
            Sounds.PlayLooping("Despacito.wav");
            TextCrawl("(c) 2019 Harry Waddle, all rights reserved\n");
            TextCrawl("Some very mild flashing lights, so cover your eyes if you want");

            if (cmdLineArgs.Length > 0) { Console.WriteLine("ARGS: {0}", cmdLineArgs); }

            Thread.Sleep(3000);

            Menu();

            Console.Clear();
            TextCrawl("What is your name? ~~>>> ", 50, false);
            Globals.Name = Console.ReadLine();
            TextCrawl("Noice.");
            Thread.Sleep(2000);

            Prologue(Globals.Name);
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
            Globals.Objective = "Pick up the can using the command 'get soup'";
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
            TextCrawl("MUM: Can you pick up that can over there?");
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
            TextCrawl("EMPLOYEE: *into mic* GET ME SECURITY GUY STEVE IN THE FOOD ISLE! WE HAVE A SOUP THEIF!");
            AwaitKey();
            TextCrawl("MUM: " + Name + ", Take the employee. I have Steve.");
            AwaitKey();

            Encounter("Employee", 30, true, true);

            Sounds.Play("Detected.flac", 60);
            TextCrawl("MUM: " + Name.ToUpper() + "! HELP!");
            AwaitKey();
            TextCrawl("You rush to help your mum against Security Guy Steve.");
            AwaitKey();

            Encounter("Security guy Steve", 69420, true, false, "Steve 1");

            TextCrawl("The tutorial is over. You're on your own now.");
            Thread.Sleep(1000);
            TextCrawl("Press any key to start...");
            AwaitKey();

            Globals.Location = Globals.LocationIndex[rnd.Next(Globals.LocationIndex.Length)];

            TextCrawl("You find yourself in the " + Globals.Location + "... Your mum is nowhere to be found.");

            switch (Globals.Location)
            {
                case "Counter":

                    Counter();

                    break;

                case "Car Park":

                    CarPark();

                    break;

                case "Food Isle":

                    FoodIsle();

                    break;

                case "D.I.Y Isle":

                    DIYIsle();

                    break;

                case "Clothes Isle":

                    ClothesIsle();

                    break;

                case "Employees Only Area":

                    EmployeesOnlyArea();

                    break;
            }
        }


        
        public static void Counter()
        {
            TextCrawl("COUNTER");
        }





        public static void CarPark()
        {
            TextCrawl("CARPARK");
        }





        public static void FoodIsle()
        {
            TextCrawl("FOODISLE");
        }





        public static void ClothesIsle()
        {
            TextCrawl("CLOTHESISLE");
        }





        public static void DIYIsle()
        {
            TextCrawl("DIYISLE");
        }





        public static void EmployeesOnlyArea()
        {
            TextCrawl("EMPLOYEESONLYAREA DESPACITO");
        }




        public static void Encounter(string EnemyName, int EnemyHealth, bool FirstStrike, bool Tutorial, string Boss = "None")  // Encounter system
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
            int PlayerLastStandChance = 50;
            int EnemyLastStandChance = 30;
            int PlayerCritChance = 10;
            int EnemyCritChance = 10;

            if (Boss == "None")
            {
                SetCol(ConsoleColor.Red);
                TextCrawl("A WILD " + EnemyName.ToUpper() + " APPEARED!");
            }

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

                SetCol(ConsoleColor.Red);
                Console.Clear();
                TextCrawl("YOUR TURN");
                Thread.Sleep(1000);

                while (true)
                {
                    Console.Clear();
                    SetCol(ConsoleColor.Green);
                    TextCrawl("It is your turn. Take advantage of your first strike and attack the enemy!");
                    TextCrawl("Attack by typing 'attack'.");

                    SetCol(ConsoleColor.Red);
                    Console.WriteLine("\n{0}'s HEALTH: {1}\nYOUR HEALTH: {2}\n\n", EnemyName, EnemyHealth, Globals.PlayerHealth);
                    SetCol(ConsoleColor.DarkYellow);
                    TextCrawl("~~>>> ", 50, false);
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
                        Console.WriteLine("{0} ATTACKS!", Globals.Name.ToUpper());
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
                        EnemyHealth -= 15;
                        Thread.Sleep(3000);
                        break;
                    }
                }

                Console.Clear();
                TextCrawl(EnemyName.ToUpper() + "'S TURN");
                Thread.Sleep(3000);

                TextCrawl(EnemyName.ToUpper() + " USES VIGOUR OF MOTIVATION! +10 LAST STAND CHANCE");
                SetCol(ConsoleColor.Green);
                TextCrawl("They just used an item that increases their chance of getting last stand.");
                Thread.Sleep(1000);
                TextCrawl("Let's use an item to increase our crit chance - use the vigour of luck by typing 'use' and then selecting it.");
                Thread.Sleep(3000);

                SetCol(ConsoleColor.Red);
                Console.Clear();
                TextCrawl("YOUR TURN");
                Thread.Sleep(1000);

                while (true)
                {
                    Console.Clear();
                    SetCol(ConsoleColor.Red);
                    Console.WriteLine("\n{0}'s HEALTH: {1}\nYOUR HEALTH: {2}\n\n", EnemyName, EnemyHealth, Globals.PlayerHealth);
                    SetCol(ConsoleColor.DarkYellow);
                    TextCrawl("~~>>> ", 50, false);
                    SetCol(ConsoleColor.Red);

                    string action = Console.ReadLine();

                    if (action.ToLower() != "use")
                    {
                        SetCol(ConsoleColor.Green);
                        TextCrawl("Try again -- see your items list by typing 'use'.");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("1 - Second Wind");
                        Console.WriteLine("2 - Vigour of Luck");
                        Console.WriteLine("3 - Heckin soup");

                        SetCol(ConsoleColor.DarkYellow);
                        TextCrawl("\n~~>>> ", 50, false);
                        SetCol(ConsoleColor.Red);

                        string choice = Console.ReadLine();

                        if (choice != "2")
                        {
                            SetCol(ConsoleColor.Green);
                            TextCrawl("\nNope. Use the vigour of luck.");
                            Thread.Sleep(1000);
                            SetCol(ConsoleColor.Red);
                        }

                        else
                        {
                            TextCrawl(Globals.Name.ToUpper() + " USES THE VIGOUR OF LUCK! +10 CRIT CHANCE!");
                            Thread.Sleep(3000);
                            break;
                        }
                    }
                }

                Console.Clear();
                TextCrawl("ENEMY TURN");
                Thread.Sleep(2000);
                Console.WriteLine("{0} ATTACKS!", EnemyName.ToUpper());
                Thread.Sleep(2000);

                Console.Clear();
                Console.WriteLine("10 DAMAGE");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("10 DAMAGE + 0");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("10 DAMAGE");
                Thread.Sleep(3000);

                SetCol(ConsoleColor.Red, "back");
                Console.Clear();
                Thread.Sleep(100);
                SetCol(ConsoleColor.Black, "back");
                Console.Clear();

                TextCrawl("You were hit for 10 damage!");
                Globals.PlayerHealth -= 10;
                Thread.Sleep(2000);

                Console.Clear();
                TextCrawl("YOUR TURN");
                Thread.Sleep(1000);
                Console.Clear();

                SetCol(ConsoleColor.Green);
                TextCrawl("Let's put that vigour to use. Attack the enemy.");
                SetCol(ConsoleColor.Red);
                Thread.Sleep(3000);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("{0}'S HEALTH: {1}\nYOUR HEALTH: {2}\n\n", EnemyName, EnemyHealth, Globals.PlayerHealth);
                    SetCol(ConsoleColor.DarkYellow);
                    TextCrawl("~~>>> ", 50, false);
                    SetCol(ConsoleColor.Red);

                    string action = Console.ReadLine();

                    if (action.ToLower() != "attack")
                    {
                        SetCol(ConsoleColor.Green);
                        TextCrawl("Nope. Attack the enemy.");
                        Thread.Sleep(3000);
                        SetCol(ConsoleColor.Red);
                    }

                    else
                    {
                        Console.Clear();

                        Console.WriteLine("10 DAMAGE");
                        Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("10 DAMAGE + CRITICAL HIT");
                        Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("10 DAMAGE + 10");
                        Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("20 DAMAGE");
                        Thread.Sleep(3000);

                        SetCol(ConsoleColor.Red, "back");
                        Console.Clear();
                        Thread.Sleep(100);
                        SetCol(ConsoleColor.Black, "back");
                        Console.Clear();

                        TextCrawl(EnemyName + " was hit for 20 damage!");
                        EnemyHealth -= 20;
                        Thread.Sleep(2000);
                        TextCrawl("The wild " + EnemyName + " fainted.");
                        Thread.Sleep(2000);
                        SetCol(ConsoleColor.Green);
                        TextCrawl("YOU WON! You got 10 Exp and 10 Gold.");
                        Thread.Sleep(3000);
                        Console.Clear();

                        break;
                    }
                }

                Thread TitleTextCrawlThread2 = new Thread(() => TitleTextCrawl("Super epic RPG (tm)", 150));
                TitleTextCrawlThread2.Start();
                Sounds.FadeOut(40, 50);
                return;
            }

            

            else if (Boss == "Steve 1")     // 1st Steve fight
            {
                Sounds.FadeOut(40, 10);
                Sounds.PlayLooping("Steve.wav");
                Sounds.SndPlayer.controls.currentPosition = 14.4;
                SetCol(ConsoleColor.Red);

                TextCrawl("SECURITY GUY STEVE TOWERS OVER YOU.");
                Thread.Sleep(1000);
                TextCrawl("FIRST STRIKE!");
                Thread.Sleep(1000);

                Console.Clear();

                TextCrawl("YOUR TURN.");
                Console.WriteLine("{0}'S HEALTH: {1}\nYOUR HEALTH: {2}", EnemyName, EnemyHealth, Globals.PlayerHealth);
                SetCol(ConsoleColor.DarkYellow);
                TextCrawl("\n~~>>> ", 50, false);
                SetCol(ConsoleColor.Red);

                string action = Console.ReadLine();

                if (action.ToLower() == "attack")
                {
                    Console.Clear();
                    TextCrawl(Globals.Name.ToUpper() + " ATTACKS!");
                    Thread.Sleep(3000);

                    Console.Clear();
                    Console.WriteLine("12 DAMAGE");
                    Thread.Sleep(1000);
                    Console.Clear();

                    Console.WriteLine("12 DAMAGE + FIRST STRIKE");
                    Thread.Sleep(1000);
                    Console.Clear();

                    Console.WriteLine("12 DAMAGE + FIRST STRIKE + CRITICAL HIT");
                    Thread.Sleep(1000);
                    Console.Clear();

                    Console.WriteLine("12 DAMAGE + 5 + CRITICAL HIT");
                    Thread.Sleep(1000);
                    Console.Clear();

                    Console.WriteLine("12 DAMAGE + 5 + 12");
                    Thread.Sleep(1000);
                    Console.Clear();

                    Console.WriteLine("17 DAMAGE + 12");
                    Thread.Sleep(1000);
                    Console.Clear();

                    Console.WriteLine("29 DAMAGE");
                    Thread.Sleep(3000);

                    SetCol(ConsoleColor.Red, "back");
                    Console.Clear();
                    Thread.Sleep(100);
                    SetCol(ConsoleColor.Black, "back");
                    Console.Clear();

                    TextCrawl("Security guy Steve was hit for 29 damage!");
                    EnemyHealth -= 29;
                    Thread.Sleep(2000);
                }

                else if (action == "use")
                {
                    Console.Clear();
                    TextCrawl("SECURITY GUY STEVE USES APPRAHEND! TURN INTERRUPTED!");
                    Thread.Sleep(2000);
                }

                TextCrawl("\nSECURITY GUY STEVE: That all you got, kid?");
                Thread.Sleep(1000);

                SetCol(ConsoleColor.Green);
                TextCrawl("We are no match for him. Let's get outta here. Use the 'run' command to attempt escape.");
                Thread.Sleep(3000);

                SetCol(ConsoleColor.Red);

                Console.Clear();
                TextCrawl("ENEMY TURN");
                Thread.Sleep(3000);
                TextCrawl("SECURITY GUY STEVE USES TASER CHARGE!");
                TextCrawl("Enemy is charging up an attack.");
                Thread.Sleep(3000);

                Console.Clear();
                SetCol(ConsoleColor.Green);
                TextCrawl("Let's escape before that attack charges up.");
                Thread.Sleep(3000);
                SetCol(ConsoleColor.Red);

                Console.Clear();
                TextCrawl("YOUR TURN");
                Thread.Sleep(1000);
                Console.Clear();

                Console.WriteLine("{0}'S HEALTH: {1}\nYOUR HEALTH: {2}", EnemyName, EnemyHealth, Globals.PlayerHealth);
                SetCol(ConsoleColor.DarkYellow);
                TextCrawl("~~>>> ", 50, false);
                SetCol(ConsoleColor.Red);

                string action2 = Console.ReadLine();

                if (action == "run")
                {
                    Console.Clear();
                    TextCrawl("ESCAPE FAILED!");
                    Thread.Sleep(2000);
                }

                Console.Clear();

                TextCrawl("ENEMY TURN");
                Thread.Sleep(3000);
                TextCrawl("SECURITY GUY STEVE: You've yeed your last haw, kid.");
                Thread.Sleep(2000);
                TextCrawl("SECURITY GUY STEVE UNLEASHED HIS CHARGED ATTACK!");
                Thread.Sleep(2000);

                SetCol(ConsoleColor.Blue, "back");
                Console.Clear();
                Thread.Sleep(100);
                SetCol(ConsoleColor.Cyan, "back");
                Console.Clear();
                Thread.Sleep(1000);

                SetCol(ConsoleColor.Blue, "back");
                Console.Clear();
                Thread.Sleep(100);
                SetCol(ConsoleColor.Cyan, "back");
                Console.Clear();
                Thread.Sleep(1000);

                SetCol(ConsoleColor.Red, "back");
                Console.Clear();
                Thread.Sleep(100);
                SetCol(ConsoleColor.Black, "back");
                Console.Clear();

                TextCrawl("You were hit for 1337 damage!");
                Thread.Sleep(1000);
                TextCrawl("YOU ARE ON LAST STAND!");
                Thread.Sleep(1000);

                SetCol(ConsoleColor.Green);
                TextCrawl("You are on last stand -- you get one turn before dying, and are limited to items and non-lethal abilities.");
                Thread.Sleep(1000);
                TextCrawl("Use second wind to escape to a random location!");
                Thread.Sleep(3000);
                Console.Clear();
                SetCol(ConsoleColor.Red);

                while (true)
                {
                    Console.Clear();
                    TextCrawl("LAST STAND ~~>>> ", 50, false);

                    string lsAction = Console.ReadLine();

                    if (lsAction != "use")
                    {
                        SetCol(ConsoleColor.Green);
                        TextCrawl("Use second wind!");
                        SetCol(ConsoleColor.Red);
                        Thread.Sleep(3000);
                    }

                    else
                    {
                        Console.WriteLine("1 - Second Wind\n2 - Heckin soup");
                        TextCrawl("\n~~>>> ", 25, false);

                        string item = Console.ReadLine();

                        if (item != "1")
                        {
                            SetCol(ConsoleColor.Green);
                            TextCrawl("Use second wind!");
                            SetCol(ConsoleColor.Red);
                            Thread.Sleep(3000);
                        }

                        else
                        {
                            Console.Clear();
                            TextCrawl(Globals.Name.ToUpper() + " USES SECOND WIND!");
                            Thread.Sleep(1000);
                            TextCrawl("ESCAPED!");
                            Thread.Sleep(3000);
                            break;
                        }
                    }
                }

                Thread TitleTextCrawlThread2 = new Thread(() => TitleTextCrawl("Super epic RPG (tm)", 150));
                TitleTextCrawlThread2.Start();
                Sounds.FadeOut(40, 50);
                return;
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



        public static int UseItem(string item)
        {
            return 69;
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


    public static class Globals
    {
        public static string[] LocationIndex = { "Car Park", "Counter", "Food Isle", "Clothes Isle", "D.I.Y Isle", "Employees Only Area" };
        public static List<string> Items = new List<string>();
        public static string Objective = "";
        public static string Location = "";
        public static string Name = "";
        public static int PlayerHealth = 100;
    }
}