using System;
using System.Threading;
using System.Diagnostics;
using WMPLib;
using System.Text;

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
            TextCrawl("Loading...");

            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Blue;
            Thread.Sleep(random.Next(1000, 3000));  // just for suspense
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


        public static void PlayLooping(string file, int vol)
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