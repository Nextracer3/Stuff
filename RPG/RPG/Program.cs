﻿using System;
using System.Threading;
using System.Media;
using System.Linq;

namespace RPG
{
    class Program
    {
        static void Main(string[] cmdLineArgs)
        {
            TitleTextCrawl("Super epic RPG (tm)");
            TextCrawl("(c) 2019 Harry Waddle, all rights reserved\n");

            if (cmdLineArgs.Length > 0) { Console.WriteLine("ARGS: {0}", cmdLineArgs); }


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
        public static SoundPlayer SndPlayer = new SoundPlayer();

        public static void Play(string file)
        {
            SndPlayer.SoundLocation = file;
            SndPlayer.Play();
        }

        public static void PlayLooping(string file)
        {
            SndPlayer.SoundLocation = file;
            SndPlayer.PlayLooping();
        }

        public static void PlaySync(string file)
        {
            SndPlayer.SoundLocation = file;
            SndPlayer.PlaySync();
        }

        public static void Stop()
        {
            SndPlayer.Stop();
        }
    }
}