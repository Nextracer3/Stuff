﻿using System;
using System.Threading;
using System.Net;

namespace SpeedTest
{
    class Program
    {
        static void Main(string[] cmdLineArgs)
        {
            if (cmdLineArgs.Length > 0) { Console.WriteLine("ARGS: {0}", cmdLineArgs); }
            Console.WriteLine("GITHUB: https://www.github.com/Nextracer3/Stuff\n\n");

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Thread TitleTextCrawlThread = new Thread(() => TitleTextCrawl("Internet Speed Test"));  
            TitleTextCrawlThread.Start();

            TextCrawl("The speed test will test the download and upload speed for your internet - this will use around 40 MB of data.");
            Thread.Sleep(1000);
            TextCrawl("Press any key to continue with the test...");
            Console.ReadKey(true);


        }


        public static void TextCrawl(string str, int ms = 50, bool endl = true) // Outputs a string to the console one character at a time, with a delay (ms) between each char
        {
            char[] chars = str.ToCharArray();   

            for (int i = 0; i < chars.Length; i++)
            {
                // For each char in the string, print the char with and delay
                Console.Write(chars[i]);
                Thread.Sleep(ms);
            }

            // If endl param is true leave a new line
            if (endl) Console.WriteLine();
        }


        public static void TitleTextCrawl(string str, int ms = 150) // Same as TextCrawl but with the window title
        {
            char[] chars = str.ToCharArray();
            string title = "";

            for (int i = 0; i < chars.Length; i++)
            {   
                // Append to the empty title string with each character and replace the title with the newly appended string each time
                title += chars[i];      
                Console.Title = title;    
                Thread.Sleep(ms);
            }
        }
    }
}
