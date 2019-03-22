using System;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace test
{
    class Program
    {
        static void Main(string[] cmdLineArgs)
        {
            Random random = new Random();

            if (cmdLineArgs.Length != 0) { Console.WriteLine("ARGS: {0}", cmdLineArgs); }


            TitleTextCrawl("Name here");
            TextCrawl("Loading...", 50, false);

            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;

            Thread.Sleep(random.Next(1000, 3000));  // just for suspense

            Menu();

            Console.Clear();
            TextCrawl("start despacito");
            TextCrawl("despacito yeet");
            Thread.Sleep(3000);
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



        public static void TitleTextCrawl(string str, int ms = 50)
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



        public static void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Sounds.PlayLooping(@"C:\ls_sfx\TestMenu.wav");

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
            Console.Clear();
            TextCrawl("instructions despacito");
            TextCrawl("despacito yeet");
            Thread.Sleep(3000);

            Menu();
        }



        public static void Settings()
        {
            Console.Clear();
            TextCrawl("settings despacito");
            TextCrawl("despacito yeet");
            Thread.Sleep(3000);

            Menu();
        }
    }


    public class Sounds
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



        public static void Stop()
        {
            SndPlayer.controls.stop();
        }
    }
}
