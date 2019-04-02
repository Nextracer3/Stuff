using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using WMPLib;
using System.Diagnostics;

namespace RPG
{
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] cmdLineArgs)
        {
            if (cmdLineArgs.Length > 0)
            {
                Console.WriteLine("ARGS: {0}\n", cmdLineArgs);
            }


            Console.CursorVisible = false;
            SetCol(ConsoleColor.Blue);


            Thread FadeInThread = new Thread(() => Sounds.FadeIn("Despacito.wav"));
            FadeInThread.Start();

            Thread TitleTextCrawlThread = new Thread(() => TitleTextCrawl("Super Epic RPG (tm)"));
            TitleTextCrawlThread.Start();

            TextCrawl("ConsoleRPG -- The survival horror game of losing your mother in Sainsbury's");
            TextCrawl("(c) 2019 Nextracer1 inc. All rights reserved.\n\nWARNING: Some mild flashing lights.");
            Sleep(5000);

            Sounds.FadeOut();
            Sounds.FadeIn("Menu.wav");

            Menu();

            Console.Clear();

            TextCrawl("What is your name? ~~>>> ", 50, false);
            Globals.PlayerName = Console.ReadLine();
            TextCrawl("Noice.");

            TextCrawl("Skip tutoiral and prologue? y/n ~~>>> ", 50, false);

            if (Console.ReadLine().ToLower() == "y")
            {
                TextCrawl("You're gonna have to do it anyway cause I've not made the actual game yet :D");
                Sleep(1000);
                Tutorial();
            }

            else
            {
                Tutorial();
            }
        }





        public static void Tutorial()
        {
            Thread AnotherFadeOutThread = new Thread(() => Sounds.FadeOut());
            AnotherFadeOutThread.Start();

            Console.Clear();

            SetCol(ConsoleColor.Cyan);

            SetCol(ConsoleColor.White, "back");
            Sleep(1000);
            SetCol(ConsoleColor.Gray, "back");
            Sleep(1000);
            SetCol(ConsoleColor.DarkGray, "back");
            Sleep(1000);
            SetCol(ConsoleColor.Black, "back");

            Sounds.Play("ShopAmbience.wav");
            Sleep(5000);



            TextCrawl("WADDLE, " + Globals.PlayerName);
            Sleep(3000);
            TextCrawl("Sainsbury's, some generic town name");
            Sleep(3000);
            TextCrawl("16:31 -- SATURDAY");

            Sleep(3000);

            Console.Clear();

            Console.WriteLine("WADDLE, " + Globals.PlayerName + "\nSainsbury's, some generic town name\n16:32 -- SATURDAY");

            Sleep(2000);

            ReverseTextCrawl("WADDLE " + Globals.PlayerName + "\nSainsbury's, some generic town name\n16:32");

            TextCrawl(Globals.PlayerName + "?");
            Sleep(1000);
            Console.WriteLine("(press any key to continue dialogue)");

            Pause();

            TextCrawl("\nYOU: Yeah?");
            Pause();
            TextCrawl("MUM: Can you get that can over there?");
            Pause();
            TextCrawl("YOU: Ok.");
            Pause();

            DisplayNewObjective("Get the can using the command 'get can'");




            string brief = "--------------------\n|=---FOOD ISLE---=|\nThere is a can of soup in front of you. ('can') An employee is standing next to it.\n\nAll directions are blocked as your mum is watching over you.\n\nITEMS: ";

            // Adding each of the player's items to the brief
            foreach (string item in Globals.Items)
            {
                brief += item + ", ";
            }

            brief += "\n\nOBJECTIVE: " + Globals.Objective + "\n--------------------";



            Console.WriteLine(brief);

            Sleep(5000);
            SetCol(ConsoleColor.Green);

            TextCrawl("\n^^^ That is a brief.\nIt is info about an area that is displayed when you enter it.");
            Sleep(2000);
            TextCrawl("A brief will say what directions other areas are in, and you can visit these areas with 'n' for north, 's' for south and so on.");
            Sleep(2000);
            TextCrawl("It will also say what enemies are nearby - you can attack them with 'attack.'");
            Sleep(2000);
            TextCrawl("You can see the brief at any time by typing 'brief'.");
            Sleep(4000);
            TextCrawl("\n\nPick up the can with the command 'get'. The ID of the item, the thing to type to pick it up, is displayed in the brief in brackets.");
            Sleep(2000);

            while (true)
            {
                SetCol(ConsoleColor.Blue);
                TextCrawl("\n~~>>> ", 50, false);
                SetCol(ConsoleColor.Cyan);

                string action = Console.ReadLine();

                if (action.ToLower() == "brief")
                {
                    SetCol(ConsoleColor.Green);
                    Console.WriteLine(brief);
                    SetCol(ConsoleColor.Cyan);
                }

                else if (action.ToLower() == "attack")
                {
                    TextCrawl("There are no enemies to attack.");
                }

                else if (action.ToLower() == "n"
                    || action.ToLower() == "e"
                    || action.ToLower() == "s"
                    || action.ToLower() == "w")
                {
                    TextCrawl("All directions are blocked as your mum is watching over you.");
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

            TextCrawl("You walk over and pick up the can.");
            Pause();
            TextCrawl("???: OI!");
            Pause();
            TextCrawl("You turn around to the face of an angry employee.");
            Pause();

            Sounds.Play("HeckinSoup.wav");

            TextCrawl("EMPLOYEE: That's me heckin' soup!");
            Pause();
            TextCrawl("Mum jumps to your defense.");
            Pause();
            TextCrawl("MUM: Sorry, we thought that soup was on sale...");
            Pause();
            TextCrawl("EMPLOYEE: You took me heckin' soup!");
            Pause();
            TextCrawl("YOU: But--");
            TextCrawl("EMPLOYEE: Security! Get me security in the food isle!");
            Pause();
            TextCrawl("EMPLOYEE RADIO: On my way.");
            Pause();
            TextCrawl("MUM: " + Globals.PlayerName + ", take the employee. I'll deal with the security.");
            Pause();

            TutorialEncounter();
        }





        public static void TutorialEncounter()
        {
            Console.Clear();

            Thread TitleTextCrawlThread = new Thread(() => TitleTextCrawl("ENCOUNTER!!!"));
            TitleTextCrawlThread.Start();

            Sounds.Play("Encounter.wav");
            Sounds.SndPlayer.controls.currentPosition = 0.5;

            for (int i = 0; i < 12; i++)
            {
                SetCol(ConsoleColor.Red, "back");
                Console.Clear();
                Sleep(100);
                SetCol(ConsoleColor.Black, "back");
                Console.Clear();
                Sleep(100);
            }

            SetCol(ConsoleColor.Red);

            TextCrawl("A WILD EMPLOYEE APPEARED!");
            Sleep(1000);

            SetCol(ConsoleColor.Green);
        }





        public static void TextCrawl(string str, int ms = 50, bool endl = true)     // TextCrawl -- Enters each character of the string parameter, one character at a time, with an interval (ms parameter) between each character. 
        {
            char[] chars = str.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
                Thread.Sleep(ms);
            }

            // Leave a new line at the end if endl is true
            if (endl) Console.WriteLine(); 
        }





        public static void ReverseTextCrawl(string str, int ms = 50)
        {
            List<char> chars = new List<char>(str.ToCharArray());

            for (int i = chars.ToArray().Length - 1; i >= 0; i--)
            {
                chars.RemoveAt(i);
                Console.Clear();

                str = "";
                foreach (char letter in chars)
                {
                    str += letter;
                }

                Console.Write(str);
                Sleep(ms);
            }
        }





        public static void IntroSplashScreen(string str, int ms = 50)
        {
            TextCrawl(str);
            Sleep(5000);

            ReverseTextCrawl(str);
        }





        public static void DisplayNewObjective(string obj)
        {
            Console.WriteLine("\n");
            SetCol(ConsoleColor.Magenta);

            Console.WriteLine("|---NEW OBJECTIVE---|");
            Sleep(1000);
            SetCol(ConsoleColor.Green);
            TextCrawl(obj + "\n\n");
            Thread.Sleep(3000);

            Globals.Objective = obj;
        }





        public static void TitleTextCrawl(string str, int ms = 150)     // TitleTextCrawl -- Same as TextCrawl, but the string is written as the Console title
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





        public static void Menu()       // Menu -- A UI for the menu.
        {
            Console.Clear();
            SetCol(ConsoleColor.Blue);

            TextCrawl(" START \n GITHUB PAGE \n EXIT ");

            Console.Clear();
            SetCol(ConsoleColor.Cyan);

            Console.WriteLine("-START-\n GITHUB PAGE \n EXIT ");

            string selected = "start";
            bool BreakWhile = false;

            while (!BreakWhile)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:

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
                            Console.WriteLine(" START \n GITHUB PAGE\n-EXIT-");
                        }

                        break;

                    case ConsoleKey.UpArrow:

                        if (selected == "exit")
                        {
                            selected = "github";

                            Console.Clear();
                            Console.WriteLine(" START\n-GITHUB PAGE-\n EXIT ");
                        }

                        else if (selected == "github")
                        {
                            selected = "start";

                            Console.Clear();
                            Console.WriteLine("-START-\n GITHUB PAGE \n EXIT ");
                        }

                        break;

                    case ConsoleKey.Enter:

                        if (selected == "start") { BreakWhile = true; }
                        else if (selected == "github") { Process.Start("chrome.exe", "https://www.github.com/Nextracer3/Stuff"); }
                        else { Environment.Exit(0); }

                        break;
                }
            }
        }





        public static void Pause()
        {
            // because ill have to type this a lot
            Console.ReadKey(true);
        }





        public static void Sleep(int ms)
        {
            Thread.Sleep(ms);
            // and this
        }










        public static void SetCol(ConsoleColor col, string ground = "fore")
        {
            if (ground == "fore")
            {
                Console.ForegroundColor = col;
            }

            else if (ground == "back")
            {
                Console.BackgroundColor = col;
                Console.Clear();
            }

            else
            {
                Console.BackgroundColor = col;
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

        public static void FadeIn(string file, int speed = 50, int EndVol = 40)
        {
            int vol = 0;

            SndPlayer.URL = file;
            SndPlayer.settings.volume = 0;

            SndPlayer.controls.play();

            for (int i = 0; i <= EndVol; i++)
            {
                vol++;
                SndPlayer.settings.volume = vol;
                Thread.Sleep(speed);
            }
        }

        public static void FadeOut(int speed = 50, int CurrentVol = 40)
        {
            int vol = CurrentVol;

            for (int i = 0; i <= CurrentVol; i++)
            {
                vol--;
                SndPlayer.settings.volume = vol;
                Thread.Sleep(speed);
            }

            Sounds.Stop();
        }
    }


    public static class Globals
    {
        // Im sorry
        public static string PlayerName = "";
        public static int PlayerHealth = 100;

        public static List<string> Items = new List<string>(new string[] { "Second Wind", "Vigour of Luck" });
        public static string Objective = "";

        public static string Location = "";
    }
}