using Lab3_appz.Events;
using System;

namespace LAB2_APPZ
{
    static class GetValidatedInput
    {
        private static GameEventManager eventManager = GameEventManager.Instance;

        public static string GetValidatedString(string parameter)
        {
            string text;
            Console.Clear();
            while (true)
            {
                Console.WriteLine($"Enter the {parameter} of the game: ");
                text = Console.ReadLine();
                if (string.IsNullOrEmpty(text))
                {
                    eventManager.LogError($"Try to enter the {parameter} again");
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
                    eventManager.LogError("Choose one of these platforms: (mobile/desktop/console)");
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
                Console.WriteLine($"Enter the {parameter} (from {minvalue} to {maxvalue}): ");
                try
                {
                    value = int.Parse(Console.ReadLine());
                }
                catch
                {
                    eventManager.LogError("The value must be an integer");
                    continue;
                }
                if (value >= minvalue && value <= maxvalue)
                {
                    break;
                }
                else
                {
                    eventManager.LogError($"Value must be from {minvalue} to {maxvalue}!");
                    continue;
                }
            }
            return value;
        }
    }
}
