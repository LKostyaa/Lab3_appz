using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB2_APPZ
{
    static class GetValidatedInput
    {
        public static string GetValidatedString(string parameter)
        {
            String text;
            Console.Clear();
            while (true)
            {

                Console.WriteLine($"Enter the {parameter} of the game: ");
                text = Console.ReadLine();
                if (String.IsNullOrEmpty(text))
                {
                    ErrorLogger.LogError($" Try to enter the {parameter} again");
                    continue;
                }
                break;
            }
            return text;
        }
        public static string GetValidatedPlatform()
        {
            string platform;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter the platform (mobile/desktop/console): ");
                platform = Console.ReadLine();
                if (platform.ToLower() == "mobile" || platform.ToLower() == "desktop" || platform.ToLower() == "console")
                {
                    break;
                }
                else
                {
                    ErrorLogger.LogError(" Choose one of these platforms: (mobile/desktop/console)");
                    continue;
                }
            }
            return platform;
        }
        public static int GetValidatedInt(string parameter, int minvalue, int maxvalue)
        {
            int value;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Enter the {parameter}(from {minvalue} to {maxvalue}): ");
                try
                {
                    value = int.Parse(Console.ReadLine());
                }
                catch
                {
                    ErrorLogger.LogError(" The value must be int");
                    continue;
                }
                if (value <= maxvalue && value >= minvalue)
                {
                    break;
                }
                else
                {
                    ErrorLogger.LogError($" Value must be from {minvalue} to {maxvalue}!");
                    continue;
                }

            }
            return value;
        }
    }
}
