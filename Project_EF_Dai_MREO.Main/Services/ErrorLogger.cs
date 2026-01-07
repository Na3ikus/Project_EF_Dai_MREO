using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DAI_MREO.UI;

namespace DAI_MREO.Services
{
    public class ErrorLogger
    {
        private readonly List<string> errorMessages = new List<string>();
        private readonly string logFilePath = "error_log.txt";

        public void Log(Exception ex)
        {
            ArgumentNullException.ThrowIfNull(ex);

            string message = $"{DateTime.Now:G} - Помилка: {ex.Message}";
            if (ex.InnerException != null)
            {
                message += $" | Внутрішня помилка: {ex.InnerException.Message}";
            }

            this.errorMessages.Add(message);

            ConsoleHelper.ShowError($"{ex.Message}. Деталі записано в журнал.");
        }

        public void DisplayMessages()
        {
            ConsoleHelper.PrintHeader("Системні повідомлення");

            if (this.errorMessages.Count == 0)
            {
                Console.WriteLine("Помилок не зафіксовано.");
                return;
            }

            foreach (var msg in this.errorMessages)
            {
                Console.WriteLine(msg);
            }

            Console.WriteLine(new string('-', Console.WindowWidth - 1));
            Console.WriteLine();
        }

        public void SaveToFile()
        {
            if (this.errorMessages.Count == 0)
            {
                Console.WriteLine("Немає повідомлень для збереження.");
                return;
            }

            try
            {
                File.WriteAllLines(this.logFilePath, this.errorMessages);
                ConsoleHelper.ShowSuccess($"Повідомлення успішно збережено у файл: {this.logFilePath}");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowError($"Не вдалося зберегти файл логів: {ex.Message}");
            }
        }

        public string GetAllMessagesAsString()
        {
            if (this.errorMessages.Count == 0)
            {
                return "Помилок не зафіксовано.";
            }

            StringBuilder sb = new StringBuilder();
            foreach (var msg in this.errorMessages)
            {
                sb.AppendLine(msg);
            }

            return sb.ToString();
        }
    }
}