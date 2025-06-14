using LogisticService.Data;
using LogisticService.Enums;
using LogisticService.Interfaces;
using LogisticService.Modules;
using System.Numerics;

namespace LogisticService.Utility
{
    internal static class Utility
    {
        public static void GetButtonKeyFromUser(out ConsoleKey consoleKey)
        {
            ConsoleKey resultKey;
            while (true)
            {
                resultKey = Console.ReadKey().Key;
                if (resultKey == ConsoleKey.D1 ||
                    resultKey == ConsoleKey.D2 ||
                    resultKey == ConsoleKey.D3 ||
                    resultKey == ConsoleKey.D4 ||
                    resultKey == ConsoleKey.D5 ||
                    resultKey == ConsoleKey.D0)
                {
                    Console.WriteLine();
                    break;
                }
            }
            consoleKey = resultKey;
        }

        public static string GetUserInput(string text)
        {
            Console.Write($"{text}: ");
            return Console.ReadLine();
        }

        public static T InputParsabilityCheck<T>(string text) where T : INumber<T>, new()
        {
            T result;
            string input = GetUserInput(text);
            while (!T.TryParse(input, null, out result))
            {
                Console.WriteLine("Invalid input! Try again\n");
                input = GetUserInput(text);
            }
            return result;
        }

        public static bool InputYesNo(string text)
        {
            while (true)
            {
                Console.Write($"{text} (y/n): ");
                string? input = Console.ReadLine()?.Trim().ToLower();

                if (input == "y" || input == "yes")
                {
                    return true;
                }
                if (input == "n" || input == "no")
                {
                    return false;
                }

                Console.WriteLine("Invalid input! Enter 'y/yes' or 'n/no'.\n");
            }
        }

        public static string InputCorrectableCheck(string text, bool? hasDigit = null)
        {
            string input = "";
            while (string.IsNullOrEmpty(input))
            {
                input = GetUserInput(text);
            }

            char[] chars = input.ToCharArray();
            if (hasDigit != null)
            {
                while ((bool)hasDigit)
                {
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (char.IsDigit(chars[i]))
                        {
                            Console.WriteLine("Input can't contain digits!\n");
                            input = GetUserInput(text);
                            break;
                        }
                    }
                    hasDigit = false;
                }
            }
            return new string(chars);
        }

        public static void ShowAllItems<T>(IEnumerable<T> repository)
        {
            foreach (var item in repository)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static string EmailCorrectableCheck(string text)
        {
            string input = "";
            while (string.IsNullOrEmpty(input))
            {
                input = GetUserInput(text);
            }

            while((!input.Contains("@mail.ru") || input.Contains("@gmail.com")) &&
                (input.Contains("@mail.ru") || !input.Contains("@gmail.com")))
            {
                Console.WriteLine("Incorrect email address!\n");
                input = GetUserInput(text);
            }
            return input;
        }
    }
}
