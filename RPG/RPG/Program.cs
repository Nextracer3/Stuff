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
            Globals.Items.Add("Second Wind");
            Globals.Items.Add("Vigour of Luck");

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
            TextCrawl("Skip tutorial? y/n ~~>>> ", 50, false);
            string skiptut = Console.ReadLine();

            if (skiptut.ToLower() == "y") { Globals.SkipTut = true; }

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
            if (Globals.SkipTut) { goto skip; }

            string Brief = "\n\n--------------------\n---FOOD ISLE---\n\nThere is a can of soup in front of you. ('can')\nIt is guarded by an employee.\n\nAll directions are blocked as your mum is watching over you.\n\nOBJECTIVE: Get the can of soup\n\nITEMS: Second Wind, Vigour of Luck\n--------------------";
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
            TextCrawl("The brief will display what areas are around you, and you can visit them with n for north, s for south and so on.");

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
            Thread.Sleep(1000);
            Sounds.Stop();
            TextCrawl("You rush to help your mum against Security Guy Steve.");
            Thread.Sleep(1000);

            Encounter("Security guy Steve", 69420, true, false, "Steve 1");

            Console.Clear();
            SetCol(ConsoleColor.Cyan);
            TextCrawl("The tutorial is over. You're on your own now.");
            Thread.Sleep(1000);
            TextCrawl("Press any key to start...");
            AwaitKey();

            skip:
            Sounds.Play("ShopAmbience.wav");
            Console.Clear();
            Globals.Location = Globals.LocationIndex[rnd.Next(Globals.LocationIndex.Length)];

            Globals.Location = "Car Park";

            TextCrawl("You find yourself at the " + Globals.Location + "... Your mum is nowhere to be found.");
            Thread.Sleep(1000);

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
            string brief = "";
            if (!Globals.SusanDead)
            {
                brief = "--------------------\n---COUNTER---\nTo the North is the car park, however the cashier will not let you out without paying.\n\nSouth is the clothes isle.\n\nTo the East is the food isle.\n\nTo the West is the D.I.Y isle.\n\nOBJECTIVE: Get past the cashier\n\nITEMS: ";
                DisplayNewObjective("GET PAST THE CASHIER\n");
            }

            else
            {
                brief = "--------------------\n---COUNTER---\nTo the North is the car park.\n\nSouth is the clothes isle.\n\nTo the East is the food isle.\n\nTo the West is the D.I.Y isle.\n\nOBJECTIVE: None\n\nITEMS: ";
            }

            foreach (string item in Globals.Items)
            {
                brief += item + ", ";
            }

            Console.WriteLine(brief);

            while (true)
            {
                SetCol(ConsoleColor.Blue);
                TextCrawl("\n~~>>> ", 50, false);
                SetCol(ConsoleColor.Cyan);

                string action = Console.ReadLine();

                if (action.ToLower() == "brief") { Console.WriteLine(brief); }

                else if (action.ToLower() == "attack")
                {
                    Encounter("Cashier Susan", 100, true, false, "Susan");
                }

                else if (action.ToLower() == "n" && !Globals.SusanDead)
                {
                    TextCrawl("\n\nSUSAN: OI!");
                    AwaitKey();
                    TextCrawl("SUSAN: YOU GOTTA PAY!");
                    AwaitKey();
                    TextCrawl("YOU: I just need to find my mum.");
                    AwaitKey();
                    TextCrawl("SUSAN: NO!");
                    AwaitKey();

                    Encounter("Cashier Susan", 100, false, false, "Susan");
                }

                else if (action.ToLower() == "n" && Globals.SusanDead)
                {
                    CarPark();
                }

                else if (action.ToLower() == "e")
                {
                    FoodIsle();
                }

                else if (action.ToLower() == "w")
                {
                    DIYIsle();
                }
            }
        }





        public static void CarPark()
        {
            Console.Clear();
            if (!Globals.AngryCivsDead) { DisplayNewObjective("GET THE KEYS FROM THE CIVILIANS\n"); }

            string brief = "";

            if (!Globals.AngryCivsDead)
            {
                brief = "--------------------\n---CAR PARK---\nThere are some angry civilians keying a car. The key says 'EMPLOYEE AREA'. ('key')\n\nTo the South is the counter.\n\nOBJECTIVE: " + Globals.Objective + "\n\nITEMS: ";
            }

            else
            {
                brief = "--------------------\n---CAR PARK---\nTo the South is the Counter.\n\nOBJECTIVES: " + Globals.Objective + "\n\nITEMS: ";
            }

            foreach (string item in Globals.Items)
            {
                brief += item + ", ";
            }

            SetCol(ConsoleColor.Green);
            Console.WriteLine(brief);

            while (true)
            {
                SetCol(ConsoleColor.Blue);
                TextCrawl("\n~~>>> ", 50, false);
                SetCol(ConsoleColor.Cyan);

                string action = Console.ReadLine();

                if (action.ToLower() == "brief")
                {
                    Console.WriteLine(brief + "\n\n");
                }

                else if (action.ToLower() == "attack" && !Globals.AngryCivsDead)
                {
                    Encounter("Angry Civilians", 50, true, false, "AngryCivs");
                }

                else if (action.ToLower() == "get key")
                {
                    TextCrawl("\n\nCIVILIAN 1: Excuse me?");
                    AwaitKey();
                    TextCrawl("YOU: I... Can I borrow those keys for a second?");
                    AwaitKey();
                    TextCrawl("CIVILIAN 2: How about no?");
                    AwaitKey();
                    TextCrawl("YOU: I need them.");
                    AwaitKey();
                    TextCrawl("CIVILIAN 1: We'll fight you for it!");
                    AwaitKey();

                    Encounter("Angry Civilians", 50, false, false, "AngryCivs");
                }

                else if (action.ToLower() == "s")
                {
                    Counter();
                }
            }
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

                if (action2.ToLower() == "run")
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



            else if (Boss == "Susan")   // Cashier Susan boss fight
            {
                bool stronk = false;
                SetCol(ConsoleColor.Red);
                Sounds.FadeOut(40, 10);
                Sounds.PlayLooping("Susan.wav");

                TextCrawl("CASHIER SUSAN BLOCKS THE WAY!");
                Thread.Sleep(2000);

                PlayerLastStandChance = 50;
                EnemyLastStandChance = 30;
                PlayerCritChance = 10;
                EnemyCritChance = 10;

                if (FirstStrike)
                {
                    TextCrawl("FIRST STRIKE!");
                    Thread.Sleep(1000);
                    DmgMod += 5;
                    turn = "player";
                }

                while (Globals.PlayerHealth > 0 && EnemyHealth > 0)
                {
                    if (turn == "player")
                    {
                        stronk = false; 
                        Console.Clear();
                        TextCrawl("YOUR TURN");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("SUSAN'S HEALTH: {0}\nYOUR HEALTH: {1}", EnemyHealth, Globals.PlayerHealth);

                        SetCol(ConsoleColor.DarkYellow);
                        TextCrawl("\n~~>>> ", 50, false);
                        SetCol(ConsoleColor.Red);

                        string action = Console.ReadLine();

                        if (action.ToLower() == "attack")
                        {
                            Console.Clear();
                            TextCrawl(Globals.Name.ToUpper() + " ATTACKS!");
                            Thread.Sleep(1000);

                            Console.Clear();

                            int dmg = rnd.Next(1, 20);

                            Console.Write("{0} DAMAGE", dmg.ToString());
                            Thread.Sleep(1000);

                            if (FirstStrike)
                            {
                                Console.Write(" + FIRST STRIKE");
                                Thread.Sleep(1000);
                                Console.Clear();

                                Console.Write("{0} DAMAGE + 5", dmg);
                                Thread.Sleep(1000);
                            }

                            if (rnd.Next(1, 100) <= PlayerCritChance)
                            {
                                Console.Write(" + CRITICAL HIT");
                                DmgMod += (dmg * 2);
                                Thread.Sleep(1000);
                                Console.Clear();

                                Console.Write("{0} DAMAGE", dmg);
                                if (FirstStrike) { Console.Write(" + 5"); Thread.Sleep(1000); }
                                Console.Write(" + {0}", dmg * 2);
                                Thread.Sleep(1000);
                            }

                            dmg += DmgMod;
                            Console.Clear();
                            Console.WriteLine("{0}", dmg);
                            Thread.Sleep(1000);

                            SetCol(ConsoleColor.Red, "back");
                            Console.Clear();
                            Thread.Sleep(100);
                            SetCol(ConsoleColor.Black, "back");
                            Console.Clear();

                            TextCrawl("Susan was hit for " + dmg + " damage!");
                            EnemyHealth -= dmg;
                            Thread.Sleep(1000);

                            dmg = 0;
                            DmgMod = 0;
                            turn = "enemy";
                        }

                        else if (action.ToLower() == "use")
                        {
                            Console.Clear();
                            TextCrawl("Items are not made yet.");
                            Thread.Sleep(1000);

                            turn = "enemy";
                        }

                        else if (action.ToLower() == "run")
                        {
                            if (rnd.Next(1, 100) <= 50)
                            {
                                Console.Clear();
                                TextCrawl("ESCAPED SUCCESSFULLY!");
                                Thread.Sleep(1000);
                                return;
                            }

                            else
                            {
                                Console.Clear();
                                TextCrawl("ESCAPE FAILED!");
                                turn = "enemy";
                            }
                        }


                        else
                        {
                            Console.Clear();
                            TextCrawl("Invalid.");
                            Thread.Sleep(1000);
                        }

                    }


                    else
                    {
                        FirstStrike = false;
                        DmgMod = 0;

                        Console.Clear();
                        TextCrawl("ENEMY TURN");
                        Thread.Sleep(1000);
                        Console.Clear();

                        int EnemyAction = rnd.Next(1, 4);

                        if (EnemyAction == 1)
                        {
                            TextCrawl("SUSAN ATTACKS!");
                            Thread.Sleep(1000);

                            int dmg = rnd.Next(1, 20);

                            Console.Write("{0} DAMAGE", dmg);
                            Thread.Sleep(1000);

                            if (rnd.Next(1, 100) <= EnemyCritChance)
                            {
                                Console.Write(" + CRITICAL HIT");
                                DmgMod += (dmg * 2);
                                Thread.Sleep(1000);
                                Console.Clear();
                                Console.Write("{0} DAMAGE + {1}", dmg, DmgMod);
                                Thread.Sleep(1000);

                                dmg += DmgMod;

                                Console.Clear();
                                Console.Write("{0} DAMAGE", dmg);
                            }

                            if (stronk)
                            {
                                TextCrawl("\nSusan has used the strength of vigour. +10 damage!");
                                Thread.Sleep(1000);
                                dmg += 10;
                            }

                            Thread.Sleep(3000);

                            SetCol(ConsoleColor.Red, "back");
                            Console.Clear();
                            Thread.Sleep(100);
                            SetCol(ConsoleColor.Black, "back");
                            Console.Clear();

                            TextCrawl("You were hit for " + dmg + " damage!");
                            Globals.PlayerHealth -= dmg;
                            Thread.Sleep(2000);

                            dmg = 0;
                            DmgMod = 0;

                            turn = "player";
                        }

                        else if (EnemyAction == 2)
                        {
                            TextCrawl("SUSAN USES VIGOUR OF STRENGTH!");
                            TextCrawl("+10 damage for next turn!");
                            Thread.Sleep(1000);
                            stronk = true;
                            turn = "player";
                        }

                        else
                        {
                            TextCrawl("SUSAN USES WEAK SMILE!");
                            Thread.Sleep(1000);
                            TextCrawl("YOUR DEFENSE HAS FALLEN!");
                            Thread.Sleep(2000);
                            turn = "player";
                        }
                    }
                }


                if (Globals.PlayerHealth < 1)
                {
                    if (rnd.Next(1, 100) <= PlayerLastStandChance)
                    {
                        Console.Clear();
                        TextCrawl("YOU ARE ON LAST STAND!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        TextCrawl("LAST STAND ~~>>> ", 50, false);

                        string lsAction = Console.ReadLine();

                        if (lsAction.ToLower() == "use")
                        {
                            TextCrawl("Items are not made yet.");
                            Thread.Sleep(1000);
                            GameOver();
                        }

                        GameOver();
                    }

                    else
                    {
                        Console.Clear();
                        GameOver();
                    }
                }

                else if (EnemyHealth < 1)
                {
                    Console.Clear();
                    SetCol(ConsoleColor.Green);
                    TextCrawl("YOU WON! YOU GOT 100 EXP AND 300 GOLD.");
                    Globals.SusanDead = true;
                    Sounds.FadeOut(40, 50);
                    Sounds.Play("ShopAmbience.wav");
                    return;
                }
            }





            else if (Boss == "AngryCivs")   // Angry civs fight
            {
                SetCol(ConsoleColor.Red);
                Sounds.FadeOut(40, 10);
                Sounds.Play("AngryCivs.flac");

                TextCrawl("ANGRY CIVILIANS DRAW NEAR!");
                Thread.Sleep(1000);

                if (FirstStrike)
                {
                    TextCrawl("FIRST STRIKE!");
                    turn = "player";
                    Thread.Sleep(1000);
                    DmgMod += 5;
                }


                if (turn == "player")
                {
                    Console.Clear();
                    TextCrawl("YOUR TURN");
                    Thread.Sleep(1000);
                    Console.Clear();

                    Console.WriteLine("ANGRY CIVILIANS' HEALTH: {0}\nYOUR HEALTH: {1}", EnemyHealth, Globals.PlayerHealth);
                    SetCol(ConsoleColor.DarkYellow);
                    TextCrawl("\n~~>>> ", 50, false);
                    SetCol(ConsoleColor.Red);

                    string action = Console.ReadLine();

                    if (action.ToLower() == "attack")
                    {

                    }
                }

                else
                {
                    TextCrawl("despacito");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

            }




            else  // Normal encounter
            {
                
            }
        }


        public static void DisplayNewObjective(string obj)
        {
            Globals.Objective = obj;
            SetCol(ConsoleColor.Magenta);
            TextCrawl("\n---NEW OBJECTIVE---");
            Thread.Sleep(1000);
            SetCol(ConsoleColor.Green);
            TextCrawl(obj);
            SetCol(ConsoleColor.Cyan);
            Thread.Sleep(1000);
            Console.WriteLine();
        }



        public static void GameOver()
        {
            Console.Clear();
            SetCol(ConsoleColor.Red);
            TextCrawl("G A M E  O V E R");
            SetCol(ConsoleColor.Blue);
            Thread.Sleep(1000);
            TextCrawl("You are dead.");
            Thread.Sleep(5000);

            Menu();
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
        public static bool SusanDead = false;
        public static bool SkipTut = false;
        public static bool AngryCivsDead = false;
    }
}







// TODO //

// Polish up Susan fight
// Finish Angry civs fight
// Finish items
// Finish the other areas