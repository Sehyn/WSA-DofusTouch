using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSA_TouchHelper
{
    internal class Utilities
    {
        public static void LoggerError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("["+DateTime.Now+"] "+message);
        }
        public static void LoggerInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[" + DateTime.Now + "] " + message);
        }
        public static void LoggerSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[" + DateTime.Now + "] " + message);
        }
    }
}
