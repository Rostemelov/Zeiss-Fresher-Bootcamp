using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseDoor
{ 
    public class Logger
    {
        // Enum to represent log levels
        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }

        // Log method to publish messages to the console
        public static void Log(LogLevel level, string message)
        {
            string logMessage = $"{DateTime.Now} [{level}] - {message}";

            // Choose console color based on log level
            ConsoleColor originalColor = Console.ForegroundColor;
            switch (level)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }

            // Publish the log message to the console
            Console.WriteLine(logMessage);

            // Reset the console color to the original color
            Console.ForegroundColor = originalColor;
        }
    }
}
