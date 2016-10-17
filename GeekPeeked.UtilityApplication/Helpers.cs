﻿using System;

namespace GeekPeeked.UtilityApplication
{
    public static class Helpers
    {
        public static void OutputMessage(string message = "", ConsoleColor color = ConsoleColor.White)
        {
            Console.ResetColor();
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

        public static void RequestInput(string message = "", ConsoleColor color = ConsoleColor.White)
        {
            Console.ResetColor();
            Console.ForegroundColor = color;
            Console.Write(string.Format("{0} => ", message));
        }
    }
}
