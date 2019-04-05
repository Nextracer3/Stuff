using System;
using System.Threading;
using WMPLib;

namespace TypeRacer
{
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] cmdLineArgs)
        {
            if (cmdLineArgs.Length > 0) { Console.WriteLine("ARGS: {0}", cmdLineArgs); }

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Sounds.FadeIn("Despacito.wav");

            Thread TitleThread = new Thread(() => TitleTextCrawl("Typeracer"));
            TitleThread.Start();

            TextCrawl("T Y P E R A C E R");
            Thread.Sleep(2000);
            TextCrawl("Press any key to continue...");

            Console.ReadKey(true);

            Menu();

            SoloPractice();
        }


        


        public static void SoloPractice()
        {
            Console.Clear();

            string[] SentenceIndex = { "The quick, brown fox jumps over the lazy dog.", "I have no idea what to put here.", "HEY GUYS ITS YA BOI ALI-A HERE WITH SOME FORTSHITE BATTLE ROYALE, TODAY WE ARE GOING TO DO A SHITTY GIVEAWAY", "Martin Luther King once said, 'I don't eat steak because it is meat that has been touched by another man, miss me with that gay shit.'", "'If you need to go for a piss, go for a piss. If you don't, don't.' - science nibba" };
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
            Thread FadeOutThread = new Thread(() => Sounds.FadeOut());
            FadeOutThread.Start();

            Thread.Sleep(1000);

            Sounds.FadeIn(@"CP.wav");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            TextCrawl(" SOLO PRACTICE \n MULTIPLAYER RACE \n EXIT");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Clear();
            Console.WriteLine("-SOLO PRACTICE-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" MULTIPLAYER RACE \n EXIT");

            string selected = "solo";
            bool BreakWhile = false;

            while (!BreakWhile)
            {
                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.DownArrow:

                        if (selected == "solo")
                        {
                            selected = "race";

                            Console.Clear();
                            Console.WriteLine(" SOLO PRACTICE ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-MULTIPLAYER RACE-");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(" EXIT ");
                        }

                        else if (selected == "race")
                        {
                            selected = "exit";

                            Console.Clear();
                            Console.WriteLine(" SOLO PRACTICE \n MULTIPLAYER RACE ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-EXIT-");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }

                        break;

                    case ConsoleKey.UpArrow:

                        if (selected == "exit")
                        {
                            selected = "race";

                            Console.Clear();
                            Console.WriteLine(" SOLO PRACTICE ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-MULTIPLAYER RACE-");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(" EXIT ");
                        }

                        else if (selected == "race")
                        {
                            selected = "solo";

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-SOLO PRACTICE-");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(" MULTIPLAYER RACE \n EXIT ");
                        }

                        break;

                    case ConsoleKey.Enter:

                        if (selected == "solo")
                        {
                            BreakWhile = true;
                        }

                        else if (selected == "race")
                        {
                            Console.Clear();
                            TextCrawl("RACE DESPACITO");
                        }

                        else
                        {
                            Environment.Exit(0);
                        }

                        break;
                }
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



        public static void Stop()
        {
            SndPlayer.controls.stop();
        }


        public static void SetLoop(bool state)
        {
            SndPlayer.settings.setMode("loop", state);
        }


        public static void FadeIn(string file, int vol = 40, int speed = 50)
        {
            int volume = 0;

            SndPlayer.URL = file;
            SndPlayer.settings.volume = volume;

            SndPlayer.controls.play();

            for (int i = 0; i <= vol; i++)
            {
                volume++;
                SndPlayer.settings.volume = volume;
                Thread.Sleep(speed);
            }
        }

        
        public static void FadeOut(int CurVol = 40, int speed = 50)
        {
            int volume = CurVol;

            for (int i = CurVol; i >= 0; i++)
            {
                volume--;
                SndPlayer.settings.volume = volume;
                Thread.Sleep(speed);
            }

            Sounds.Stop();
        }
    }
}