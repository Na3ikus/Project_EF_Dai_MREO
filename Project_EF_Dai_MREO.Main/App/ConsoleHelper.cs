using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DAI_MREO.UI.Design;

namespace DAI_MREO.UI
{
    public static class ConsoleHelper
    {
        public static void PrintHeader(string title)
        {
            Window.DrawHeader(title);
        }

        public static void ShowError(string message)
        {
            Window.ShowError(message);
        }

        public static void ShowSuccess(string message)
        {
            Window.ShowSuccess(message);
        }

        public static string ReadPassword(string prompt)
        {
            Console.ForegroundColor = Window.Theme.PrimaryColor;
            Console.Write(prompt);
            Console.ResetColor();

            StringBuilder password = new StringBuilder();

            while (true)
            {
                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.Remove(password.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            }

            return password.ToString();
        }

        public static int ShowInteractiveMenu(string title, IEnumerable<string> options)
        {
            var optionsList = new List<string>(options);
            int selectedIndex = 0;

            Console.CursorVisible = false;

            while (true)
            {
                Window.DrawHeader(title);
                Console.WriteLine("  (Навігація: \u2191/\u2193, Вибір: Enter)\n");

                for (int i = 0; i < optionsList.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = Window.Theme.SecondaryColor;
                        Console.ForegroundColor = Window.Theme.BackgroundColor;
                        Console.WriteLine($"  >> {optionsList[i].PadRight(Console.WindowWidth - 6)}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = Window.Theme.SecondaryColor;
                        Console.WriteLine($"     {optionsList[i]}");
                        Console.ResetColor();
                    }
                }

                var keyInfo = Console.ReadKey(intercept: true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex == 0) ? optionsList.Count - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex == optionsList.Count - 1) ? 0 : selectedIndex + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return selectedIndex;
                }
            }
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.ForegroundColor = Window.Theme.SecondaryColor;
            Console.WriteLine("Натисніть Enter, щоб продовжити...");
            Console.ResetColor();
            Console.ReadLine();
        }

        public static bool Confirm(string message)
        {
            Console.ForegroundColor = Window.Theme.PrimaryColor;
            Console.Write($"\n{message} (Y/N): ");
            Console.ResetColor();
            return Console.ReadLine()?.ToUpper(CultureInfo.CurrentCulture) == "Y";
        }

        public static string ReadString(string prompt, int maxLength, bool isNullable = false)
        {
            while (true)
            {
                Console.ForegroundColor = Window.Theme.SecondaryColor;
                Console.Write(prompt);
                Console.ForegroundColor = Window.Theme.TextColor;
                string? input = Console.ReadLine();
                Console.ResetColor();

                if (isNullable && string.IsNullOrWhiteSpace(input))
                {
                    return string.Empty;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Window.ShowError("Ввід не може бути порожнім.");
                    continue;
                }

                if (input.Length > maxLength)
                {
                    Window.ShowError($"Макс. довжина: {maxLength} символів.");
                    continue;
                }

                return input;
            }
        }

        public static long ReadLong(string prompt)
        {
            while (true)
            {
                Console.ForegroundColor = Window.Theme.SecondaryColor;
                Console.Write(prompt);
                Console.ForegroundColor = Window.Theme.TextColor;

                if (long.TryParse(Console.ReadLine(), out long id))
                {
                    Console.ResetColor();
                    return id;
                }
                else
                {
                    Console.ResetColor();
                    Window.ShowError("Некоректний ID. Введіть число.");
                }
            }
        }

        public static DateTime ReadDateTime(string prompt)
        {
            while (true)
            {
                Console.ForegroundColor = Window.Theme.SecondaryColor;
                Console.Write(prompt);
                Console.ForegroundColor = Window.Theme.TextColor;

                if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    Console.ResetColor();
                    return date;
                }
                else
                {
                    Console.ResetColor();
                    Window.ShowError("Некоректний формат дати (дд.мм.рррр).");
                }
            }
        }
    }
}