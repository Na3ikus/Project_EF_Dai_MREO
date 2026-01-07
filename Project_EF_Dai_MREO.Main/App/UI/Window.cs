using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DAI_MREO.UI.Design
{
    public static class Window
    {
        public static IColorTheme Theme { get; set; } = new NeonTheme();

        public static void DrawHeader(string title)
        {
            ArgumentNullException.ThrowIfNull(title);

            int width;
            try
            {
                Console.Clear();
                width = Console.WindowWidth - 4;
            }
            catch (Exception)
            {
                width = 60;
            }

            string border = new string(Theme.Horizontal[0], Math.Max(1, width));

            try
            {
                Console.ForegroundColor = Theme.PrimaryColor;

                Console.WriteLine($" {Theme.TopLeft}{border}{Theme.TopRight}");

                string centeredTitle = CenterText(title.ToUpper(System.Globalization.CultureInfo.CurrentCulture), width);
                Console.WriteLine($" {Theme.Vertical}{centeredTitle}{Theme.Vertical}");

                Console.WriteLine($" {Theme.BottomLeft}{border}{Theme.BottomRight}");
                Console.ResetColor();
                Console.WriteLine();
            }
            catch (IOException)
            {
                // If writing to console fails, silently ignore in tests
            }
        }

        public static void DrawTable(string[] headers, ReadOnlyCollection<string[]> rows, int[] colWidths)
        {
            ArgumentNullException.ThrowIfNull(headers);
            ArgumentNullException.ThrowIfNull(rows);
            ArgumentNullException.ThrowIfNull(colWidths);
            if (headers.Length != colWidths.Length)
            {
                throw new ArgumentException("Кількість колонок і ширина повинні збігатися");
            }

            Console.ForegroundColor = Theme.SecondaryColor;

            Console.ForegroundColor = Theme.PrimaryColor;
            PrintRow(headers, colWidths);

            Console.ForegroundColor = Theme.SecondaryColor;
            Console.WriteLine(new string('-', colWidths.Sum() + (colWidths.Length * 3)));

            Console.ForegroundColor = Theme.TextColor;
            if (rows.Count == 0)
            {
                Console.WriteLine("  Дані відсутні.");
            }
            else
            {
                foreach (var row in rows)
                {
                    PrintRow(row, colWidths);
                }
            }

            Console.ResetColor();
        }

        public static void ShowError(string message)
        {
            Console.ForegroundColor = Theme.ErrorColor;
            Console.WriteLine($" [!] {message}");
            Console.ResetColor();
        }

        public static void ShowSuccess(string message)
        {
            Console.ForegroundColor = Theme.SuccessColor;
            Console.WriteLine($" [OK] {message}");
            Console.ResetColor();
        }

        private static void PrintRow(string[] columns, int[] width)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                string text = columns[i];
                if (text.Length > width[i])
                {
                    text = string.Concat(text.AsSpan(0, width[i] - 3), "...");
                }

                Console.Write($"{text.PadRight(width[i])} {Theme.Vertical} ");
            }

            Console.WriteLine();
        }

        private static string CenterText(string text, int width)
        {
            if (text.Length >= width)
            {
                return text;
            }

            int leftPadding = (width - text.Length) / 2;
            int rightPadding = width - text.Length - leftPadding;
            return new string(' ', leftPadding) + text + new string(' ', rightPadding);
        }
    }
}