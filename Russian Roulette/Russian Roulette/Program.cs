using System;
using System.Threading;
using System.Diagnostics;
using WMPLib;
using System.Text;
using System.Windows.Forms;

namespace RussianRoulette
{
    class Program
    {
        public static Random random = new Random(); 
        static void Main(string[] cmdLineArgs)
        {
            if (cmdLineArgs.Length != 0)
            {
                Console.WriteLine("ARGS: {0}", cmdLineArgs);
            }

            // INIT //

            Console.CursorVisible = false;

            TitleTextCrawl("Russian Roulette", 150);
            TextCrawl("Loading...", 50, false);

            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Blue;
            Thread.Sleep(random.Next(1000, 3000));  // just for suspense
            Console.WriteLine("     DONE");
            Thread.Sleep(1000);


            //


            Menu();


            
            string Player2Name, Player1Name = SystemInformation.UserName;

            TextCrawl("Is " + Player1Name + " your name? (y/n) >>>");
            var key = Console.ReadKey(true);

            switch(key.Key.ToString().ToLower())
            {
                case "y":
                    TextCrawl("\nYep. Don't ask how I got it.");
                    Thread.Sleep(1000);
                    TextCrawl("\nEnter Player 2's name >>> ", 50, false);
                    Player2Name = Console.ReadLine();
                    TextCrawl("Game starting...");
                    Thread.Sleep(3000);

                    TextCrawl("player 1     " + Player1Name);
                    TextCrawl("player 2     " + Player2Name);

                    break;

                case "n":

                    TextCrawl("Enter your name >>> ", 50, false);
                    Player1Name = Console.ReadLine();
                    TextCrawl("\nEnter Player 2's name >>> ", 50, false);
                    Player2Name = Console.ReadLine();
                    TextCrawl("Game starting...");
                    Thread.Sleep(3000);

                    TextCrawl("player 1     " + Player1Name);
                    TextCrawl("player 2     " + Player2Name);

                    break;

                default:
                    break;
            }

            // ACTUAL GAME START //



        }





        public static void TextCrawl(string str, int ms = 50, bool endl = true)
        {
            char[] chars = str.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
                Thread.Sleep(ms);
            }

            if (endl) Console.WriteLine();  // new line if the endl parameter is true
        }


        public static void TitleTextCrawl(string str, int ms = 50)
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





        public static void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Sound.PlayLooping(@"C:\ls_sfx\TestMenu.wav");

            TextCrawl(" START \n INSTRUCTIONS \n SETTINGS \n EXIT ");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-START-\n INSTRUCTIONS \n SETTINGS \n EXIT ");

            string selected = "start";
            bool BreakWhile = false;

            while (!BreakWhile)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:


                        if (selected == "exit")
                        {
                            selected = "settings";
                            Console.Clear();
                            Console.WriteLine(" START \n INSTRUCTIONS\n-SETTINGS-\n EXIT ");

                        }

                        else if (selected == "settings")
                        {
                            selected = "instructions";
                            Console.Clear();
                            Console.WriteLine(" START \n-INSTRUCTIONS-\n SETTINGS \n EXIT ");
                        }

                        else if (selected == "instructions")
                        {
                            selected = "start";
                            Console.Clear();
                            Console.WriteLine("-START-\n INSTRUCTIONS \n SETTINGS \n EXIT ");

                        }

                        break;

                    case ConsoleKey.DownArrow:

                        if (selected == "start")
                        {
                            selected = "instructions";
                            Console.Clear();
                            Console.WriteLine(" START \n-INSTRUCTIONS-\n SETTINGS \n EXIT ");

                        }

                        else if (selected == "instructions")
                        {
                            selected = "settings";
                            Console.Clear();
                            Console.WriteLine(" START \n INSTRUCTIONS \n-SETTINGS-\n EXIT ");

                        }

                        else if (selected == "settings")
                        {
                            selected = "exit";
                            Console.Clear();
                            Console.WriteLine(" START \n INSTRUCTIONS \n SETTINGS \n-EXIT-");

                        }

                        break;

                    case ConsoleKey.Enter:

                        if (selected == "start") { BreakWhile = true; }

                        else if (selected == "instructions") { Instructions(); }

                        else if (selected == "settings") { Settings(); }

                        else if (selected == "exit") { Environment.Exit(0); }

                        else { Console.WriteLine("===DEBUG===\nselected was {0}", selected); }

                        break;
                }
            }
        }


        public static void Instructions()
        {
            TextCrawl("Instructions placeholder");
            Thread.Sleep(1000);
            Menu();
        }


        public static void Settings()
        {
            TextCrawl("Settings placeholder");
            Thread.Sleep(1000);
            Menu();
        }
    }

    public class Sound
    {
        public static WindowsMediaPlayer SndPlayer = new WindowsMediaPlayer();      

        public static void Play(string file, int vol = 40)
        {
            SndPlayer.controls.stop();

            SndPlayer.URL = file;
            SndPlayer.settings.volume = vol;

            SndPlayer.controls.play();
        }


        public static void PlayLooping(string file, int vol = 40)
        {
            SndPlayer.controls.stop();

            SndPlayer.URL = file;
            SndPlayer.settings.volume = vol;
            SndPlayer.settings.setMode("loop", true);

            SndPlayer.controls.play();
        }


        public static void Stop() => SndPlayer.controls.stop();
    }
}